using Datos.EF.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Datos.EF
{
    /// <summary>
    /// Clase genérica para operaciones CRUD en SQL Server usando Entity Framework Core
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatosSQL<T> where T : class
    {
        private readonly OpenSuiteDbContext _context;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Constructor que recibe el contexto de la base de datos
        /// </summary>
        /// <param name="context"></param>
        public DatosSQL(OpenSuiteDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        #region "generales"


        /// <summary>
        /// Obtener el máximo ID de una tabla para un campo específico
        /// </summary>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public async Task<TKey> GetMaxIdAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            try
            {
                if (keySelector == null)
                    throw new ArgumentNullException(nameof(keySelector));

                var query = _dbSet.Select(keySelector);

                // Si la tabla está vacía
                if (!await query.AnyAsync())
                {
                    return (TKey)Convert.ChangeType(1, typeof(TKey));
                }

                return await query.MaxAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// obtiene los nombres de de una clase
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static string GetPropertyName<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            if (keySelector.Body is MemberExpression member)
                return member.Member.Name;

            if (keySelector.Body is UnaryExpression unary && unary.Operand is MemberExpression memberExpr)
                return memberExpr.Member.Name;

            throw new ArgumentException("Key selector must be a property expression.");
        }

        public IQueryable<T> Query(bool asNoTracking = false)
        {
            var query = _dbSet.AsQueryable();
            if (asNoTracking)
                query = query.AsNoTracking();

            return query;
        }


        /*
         * 
         //////////////////////////////////////
            ejemplo de uso
        //////////////////////////////////////
        
        ////////////////////////////////////////////////////////////
        sin parametros de entradas
        ////////////////////////////////////////////////////////////

        1. ejecutas con el nombre del procedimiento
            var (resultados, salidas) = await _repository.EjecutarProcedimiento<TUMODELO>("sprName");


        ////////////////////////////////////////////////////////////
        con parametros de entrada
        ////////////////////////////////////////////////////////////


        1. declara los parametros de entradas

            var parametros = new[]
            { 
               new SqlParameter("@EmpresaID", id),
            };


        2. ejecutas con los parametros
            var (empresa, salidas) = await _repository.EjecutarProcedimiento<TUMODELO>("sprName", parametros);



        ////////////////////////////////////////////////////////////
        // con parametros de entrada y salida
        ////////////////////////////////////////////////////////////
       
        1. declara los parametros de entradas y salidas
            var parametros = new[]
            { 
               new SqlParameter("@EmpresaID", id),
               new SqlParameter("@Salida", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output }
            };

        2. ejecutas con los parametros
            var (empresa, salidas) = await _repository.EjecutarProcedimiento<TUMODELO>("sprName", parametros);

        ////////////////////////////////////////////////////////////
        /// solo parametros de salida
        ////////////////////////////////////////////////////////////
       
        1. declara los parametros de salidas
            var parametros = new[]
            { 
                new SqlParameter("@EmpresaID", id),
                new SqlParameter("@Salida", SqlDbType.NVarChar) { Direction = ParameterDirection.Output }
            };
        2. ejecutas con los parametros, pbsrvar que no es necesario el tipo de modelo
             var (_, salidas) = await _datos.EjecutarProcedimiento<TUMODELO>("sprName", parametros);


        */


        /// <summary>
        /// Ejecutar un procedimiento almacenado con parámetros de entrada y salida
        /// </summary>
        /// <typeparam name="TEntity">El modelo de EF</typeparam>
        /// <param name="spName">nombre del procedimiento almacenado</param>
        /// <param name="parametros">listado de parametros de entrada/salida</param>
        /// <returns></returns>
        public async Task<(List<TEntity> Resultados, Dictionary<string, object?> Salidas)> EjecutarProcedimiento<TEntity>(string spName, params SqlParameter[] parametros) where TEntity : class
        {
            var connection = _context.Database.GetDbConnection();
            await using var cmd = connection.CreateCommand();
            try
            {
                var salida = new Dictionary<string, object?>();
                var resultados = new List<TEntity>();


                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var p in parametros)
                    cmd.Parameters.Add(p);

                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                // Si la entidad no es "object", intentamos mapear con EF
                if (typeof(TEntity) != typeof(object))
                {
                    // Construimos la llamada EXEC con placeholders
                    string sql = $"EXEC {spName} {string.Join(", ", parametros.Select(p => p.ParameterName))}";

                    resultados = await _context.Set<TEntity>().FromSqlRaw(sql, parametros).ToListAsync();
                }
                else
                {
                    // Ejecutamos como NonQuery (solo parámetros de salida)
                    await cmd.ExecuteNonQueryAsync();
                }

                // Recuperamos parámetros de salida
                foreach (SqlParameter p in cmd.Parameters)
                {
                    if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput)
                        salida[p.ParameterName] = p.Value;
                }

                return (resultados, salida);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();

                connection.Close();
                connection.Dispose();
            }
        }


        /// <summary>
        /// Insertar varias operaciones en una transacción, enviar las operaciones como delegados
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteInTransactionAsync(Func<Task> operations)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Ejecuta todas las operaciones dentro del delegado
                await operations();

                // Guardar cambios y confirmar transacción
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        #endregion

        #region "selects"
        /// <summary>
        /// Listar todos los registros
        /// 
        /*  EJEMPLO de uso
            filter: e => e.Activa == true,                              // filtro
            orderBy: q => q.OrderByDescending(e => e.Nombre),           // orden
            include: q => q                                            // include + thenInclude
                .Include(e => e.Pais)
                .Include(e => e.GiroEconomicos)
                .Include(e => e.Duenos)
                    .ThenInclude(d => d.Direccion)
                    .ThenInclude(dir => dir.Municipio),
            asNoTracking: true                                          // sin tracking
         
         */
        /// </summary>
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? include = null, bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }


        /// <summary>
        /// Buscar por clave primaria usando un selector de clave
        /*
                keyValue: 5,
                keySelector: e => e.EmpresaID,
                include: q => q.Include(e => e.Pais),
                asNoTracking: true
        */
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keyValue"></param>
        /// <param name="keySelector"></param>
        /// <param name="include"></param>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync<TKey>(TKey keyValue, Expression<Func<T, TKey>> keySelector, Func<IQueryable<T>, IQueryable<T>>? include = null, bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            // Construimos la expresión e => e.Propiedad == keyValue
            var parameter = Expression.Parameter(typeof(T), "e");
            var body = Expression.Equal(
                Expression.Invoke(keySelector, parameter),
                Expression.Constant(keyValue, typeof(TKey))
            );
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return await query.FirstOrDefaultAsync(lambda);
        }

        /// <summary>
        /// Buscar por cualquier condición
        /// sirve para muchas condiciones de busqueda
        /// 
        /// predicate: e => e.CiudadID == CiudadID && e.PaisID == PaisID,
        /// include: q => q.Include(c => c.Pais),
        /// asNoTracking: true
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
                query = include(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }




        /// <summary>
        /// Buscar por clave primaria usando FindAsync (solo para claves simples)
        /// </summary>
        public async Task<T?> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }
        #endregion

        #region "insercciones"
        /// <summary>
        /// Insertar un registro inmediatamente
        /// </summary>
        public async Task<T> InsertAsync(T model)
        {
            try
            {
                await _dbSet.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insertar varios registros
        /// </summary>
        public async Task<List<T>> InsertRangeAsync(List<T> models)
        {
            try
            {
                await _dbSet.AddRangeAsync(models);
                await _context.SaveChangesAsync();
                return models;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Insertar un registro sin guardar cambios (SaveChanges) inmediatamente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> InsertWithoutSaveAsync(T model)
        {
            try
            {
                await _dbSet.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException?.Message);
            }
        }



        /// <summary>
        /// Insertar varios registros sin guardar cambios (SaveChanges) inmediatamente
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<List<T>> InsertRangeWithoutSaveAsync(List<T> models)
        {
            await _dbSet.AddRangeAsync(models);
            return models;
        }
        #endregion

        #region "actualizaciones"
        /// <summary>
        /// Actualizar un registro
        /// </summary>
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Actualizar varios registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateRangeAsync(List<T> entity)
        {
            try
            {
                _dbSet.UpdateRange(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyPropertyName"></param>
        /// <returns></returns>
        public async Task<bool> UpdateWithCollectionsAsync(T entity, string keyPropertyName)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Actualizar entidad principal
                _context.Entry(entity).State = EntityState.Modified;

                // Sincronizar colecciones relacionadas
                await UpdateCollectionsAsync(entity, keyPropertyName);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// permite actualizar todas las colecciones asociadas al modelo
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fkPropertyName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task UpdateCollectionsAsync(T entity, string fkPropertyName)
        {
            var entityType = entity.GetType();

            // Obtener valor de la FK en la entidad padre (ej. EmpresaID)
            var fkValue = entityType.GetProperty(fkPropertyName)?.GetValue(entity);
            if (fkValue == null) throw new InvalidOperationException($"La propiedad FK '{fkPropertyName}' no existe o es null.");

            // Recorremos las propiedades que son colecciones (ICollection<TChild>)
            var props = entityType.GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()))
                .ToList();

            foreach (var prop in props)
            {
                var listaNuevaObj = prop.GetValue(entity) as IEnumerable;
                if (listaNuevaObj == null) continue;

                // Obtener tipo hijo (TChild)
                var tipoEntidad = prop.PropertyType.GetGenericArguments()[0];

                // 1) Obtener las entidades existentes en BD (por FK) como List<object>
                var existentes = await GetExistingEntitiesByForeignKeyAsync(tipoEntidad, fkPropertyName, fkValue);

                // 2) Determinar la PK del tipo hijo mediante metadata de EF (más robusto que supuestos de nombre)
                var efEntityType = _context.Model.FindEntityType(tipoEntidad);
                var pkProp = efEntityType?.FindPrimaryKey()?.Properties.FirstOrDefault()?.Name;
                if (pkProp == null)
                {
                    // Si no encontramos PK, saltamos esta colección
                    continue;
                }

                var pkPropertyInfo = tipoEntidad.GetProperty(pkProp);
                var fkPropertyInfo = tipoEntidad.GetProperty(fkPropertyName);

                if (pkPropertyInfo == null || fkPropertyInfo == null)
                    continue;

                // Convertir lista nueva a List<object> para manipular
                var listaNueva = listaNuevaObj.Cast<object>().ToList();

                // 3) Eliminar los existentes que no están en la nueva lista
                foreach (var existente in existentes)
                {
                    var idExistente = pkPropertyInfo.GetValue(existente);
                    bool existeEnNueva = listaNueva.Any(n =>
                    {
                        var idNuevo = pkPropertyInfo.GetValue(n);
                        return idNuevo != null && idNuevo.Equals(idExistente);
                    });

                    if (!existeEnNueva)
                    {
                        _context.Remove(existente);
                    }
                }

                // 4) Insertar nuevos o actualizar existentes
                foreach (var nuevo in listaNueva)
                {
                    var idNuevo = pkPropertyInfo.GetValue(nuevo);
                    if (idNuevo == null || Convert.ToInt64(idNuevo) == 0)
                    {
                        // nuevo: asignar FK y agregar
                        fkPropertyInfo.SetValue(nuevo, fkValue);
                        _context.Add(nuevo); // Add sin async porque no es necesario
                    }
                    else
                    {
                        // existente: marcar como modificado (lo attachará si no está trackeado)
                        _context.Entry(nuevo).State = EntityState.Modified;
                    }
                }
            }
        }


        #endregion

        #region "eliminacion"
        /// <summary>
        /// Eliminar por entidad
        /// </summary>
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Eliminar por clave primaria
        /// </summary>
        public async Task<bool> DeleteByIdAsync(params object[] keyValues)
        {
            var entity = await GetByIdAsync(keyValues);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoEntidad"></param>
        /// <param name="foreignKeyName"></param>
        /// <param name="fkValue"></param>
        /// <returns></returns>
        private async Task<List<object>> GetExistingEntitiesByForeignKeyAsync(Type tipoEntidad, string foreignKeyName, object fkValue)
        {
            // 1) Obtener IQueryable (DbSet<T>) dinámicamente: _context.Set<T>()
            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!.MakeGenericMethod(tipoEntidad);
            var dbSetObj = setMethod.Invoke(_context, null);
            if (dbSetObj == null) return new List<object>();
            var queryable = (IQueryable)dbSetObj;

            // 2) Construir expresión: e => EF.Property<FKType>(e, foreignKeyName) == fkValue
            var parameter = Expression.Parameter(tipoEntidad, "e");

            // EF.Property<FKType>(e, "ForeignKey")
            var efPropertyMethod = typeof(Datos.EF.Context.OpenSuiteDbContext)
                .GetMethod(nameof(Datos.EF.Context.OpenSuiteDbContext), BindingFlags.Public | BindingFlags.Static)!
                .MakeGenericMethod(fkValue.GetType());

            var propertyAccess = Expression.Call(efPropertyMethod, parameter, Expression.Constant(foreignKeyName));
            var body = Expression.Equal(propertyAccess, Expression.Constant(fkValue, fkValue.GetType()));

            var lambdaType = typeof(Func<,>).MakeGenericType(tipoEntidad, typeof(bool));
            var lambda = Expression.Lambda(lambdaType, body, parameter);

            // 3) Aplicar Queryable.Where<T>(queryable, lambda)
            var whereMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Where" && m.GetParameters().Length == 2)
                .MakeGenericMethod(tipoEntidad);

            var filteredQuery = (IQueryable)whereMethod.Invoke(null, new object[] { queryable, lambda })!;

            // 4) Ejecutar ToListAsync<T>(filteredQuery)
            var toListAsyncMethod = typeof(EntityFrameworkQueryableExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "ToListAsync")
                .Select(m => new { Method = m, Params = m.GetParameters() })
                .First(m => m.Params.Length == 1) // ToListAsync(IQueryable<T>) overload
                .Method
                .MakeGenericMethod(tipoEntidad);

            var taskObj = (Task)toListAsyncMethod.Invoke(null, new object[] { filteredQuery })!;
            await taskObj.ConfigureAwait(false);

            // Obtener el Result (List<T>) mediante reflexión
            var resultProperty = taskObj.GetType().GetProperty("Result");
            var resultList = (IList?)resultProperty?.GetValue(taskObj);

            return resultList?.Cast<object>().ToList() ?? new List<object>();
        }
    }
}


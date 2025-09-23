namespace Shared.Encrypt
{
    /// <summary>
    /// Servicio para el manejo de contraseñas utilizando BCrypt
    /// </summary>
    public class PasswordService : IPasswordService
    {
        private readonly int _workFactor;

        /// <summary>
        /// Constructor del servicio de contraseñas
        /// </summary>
        /// <param name="workFactor"></param>
        public PasswordService(int workFactor = 12) // 12 es un buen equilibrio entre seguridad y rendimiento
        {
            _workFactor = workFactor;
        }

        /// <summary>
        /// Hashear una contraseña
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        /// <summary>
        /// Verificar una contraseña contra un hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        /// <summary>
        /// Determinar si un hash necesita ser re-hasheado (por ejemplo, si el work factor ha cambiado)
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public bool NeedsRehash(string hashedPassword)
        {
            return BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, _workFactor);
        }
    }
}

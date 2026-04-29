namespace ProjetoEmprestimo.Cookie
{
    public class Cookie
    {
        private IHttpContextAccessor _context;
        private IConfiguration _configuration;

        public Cookie(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        //Cadastrar
        public void Cadastrar(string Key, string Valor)
        {
            CookieOptions Options = new CookieOptions();
            Options.Expires = DateTime.Now.AddDays(7);
            Options.IsEssential = true;

            _context.HttpContext.Response.Cookies.Append(Key, Valor, Options);
        }
    }
}

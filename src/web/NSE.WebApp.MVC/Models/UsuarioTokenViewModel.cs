using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public class UsuarioTokenViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<UsuarioClaimViewModel> Claims { get; set; }
    }
}

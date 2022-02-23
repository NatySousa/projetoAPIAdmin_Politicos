using System;
using System.IO;
using System.Threading.Tasks;
using Admin_API.ViewModels.Deputado;
using Microsoft.AspNetCore.Http;

namespace Admin_API.Util
{
    public class UploadImagem
    {
        public async Task<string> Image(IFormFile imagem)
        {
            if (imagem == null)
            {
                return string.Empty;
            }
            var guid = Guid.NewGuid();

            var path = Path.Combine("wwwroot", guid + ".jpg");

            if (imagem != null)
            {
                var fileStram = new FileStream(path, FileMode.Create);
                await imagem.CopyToAsync(fileStram);
            }

            return path;
        }
    }
}
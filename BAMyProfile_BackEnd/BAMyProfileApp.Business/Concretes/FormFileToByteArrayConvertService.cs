using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public static class FormFileToByteArrayConvertService
    {

            public static async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
            {
                if (file == null || file.Length == 0)
                    return null;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        
    }
}
using AutoMapper;
using BAMyProfileApp.Dtos.Cv;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class ByteArrayToBase64ResolveService<TSource> : IValueResolver<TSource, object, string>
    {
        private readonly string _sourcePropertyName;

        public ByteArrayToBase64ResolveService(string sourcePropertyName)
        {
            _sourcePropertyName = sourcePropertyName;
        }

        public string Resolve(TSource source, object destination, string destMember, ResolutionContext context)
        {
            var property = typeof(TSource).GetProperty(_sourcePropertyName);
            if (property != null)
            {
                var byteArray = property.GetValue(source) as byte[];
                if (byteArray != null)
                {
                    return Convert.ToBase64String(byteArray);
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IRecaptchaService
    {
        /// <summary>
        /// Check is recaptchaToken іs valid
        /// </summary>
        /// <param name="recaptchaToken">Recaptcha token</param>
        /// <returns></returns>
        bool IsValid(string recaptchaToken);
    }
}

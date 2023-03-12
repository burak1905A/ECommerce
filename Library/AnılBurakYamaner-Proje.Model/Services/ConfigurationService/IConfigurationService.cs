using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Services.ConfigurationService
{
    public interface IConfigurationService
    {
      
            IConfiguration GetConfiguration();
       
    }
}

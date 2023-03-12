using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Models
{
    public class WebApiResponse<T>
    {
        public WebApiResponse()
        {

        }
        public WebApiResponse(bool isSuccess, string resultMessage)
        {
            IsSuccess = isSuccess;
            ResultMessage = resultMessage;
        }

        public WebApiResponse(bool isSuccess, string resultMessage, T resultData)
        {
            IsSuccess = isSuccess;
            ResultMessage = resultMessage;
            ResultData = resultData;
        }

        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
        public T ResultData { get; set; }
    }
}

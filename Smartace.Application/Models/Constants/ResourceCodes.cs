using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Models.Constants
{
    public static class ResourceCodes
    {
        #region Global
        public const string FeatureNotAvailable = "006";
        public const string ServiceError = "004";
        public const string NullPayload = "007";
        public const string Success = "000";

        public const string Unauthenticated = "001";

        public const string ValidationError = "002";

        public const string NoData = "005";

        #endregion Global

       

        #region Auth 
        public const string InvalidLoginDetails = "100";

        public const string InvalidToken = "110";
       
        #endregion Auth

      
    }
}

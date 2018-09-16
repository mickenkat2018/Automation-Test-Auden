using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auden_Exercise.PageElements
{
    public class LoginPageElements
    {
        public string TxtLoginEmail
        {
            get
            {
                return "email";
            }
        }

        public string TxtLoginPassword
        {
            get
            {
                return "passwd";
            }
        }

        public string BtnLoginSubmission
        {
            get
            {
                return "//button[@id='SubmitLogin']//span";
            }
        }

        public string TxtEmailCreate
        {
            get
            {
                return "email_create";
            }
        }

        public string BtnCreateNewAccount
        {
            get
            {
                return "//button[@id='SubmitCreate']//span";
            }
        }

        public string RdoGender
        {
            get
            {
                return "//div[@id='uniform-id_gender1']";
            }
        }

        public string TxtCustomerFirstname
        {
            get
            {
                return "customer_firstname";
            }
        }

        public string TxtCustomerLastname
        {
            get
            {
                return "customer_lastname";
            }
        }

        public string DdlDays
        {
            get
            {
                return "//select[@id='days']";
            }
        }

        public string DdlMonths
        {
            get
            {
                return "//select[@id='months']";
            }
        }

        public string DdlYears
        {
            get
            {
                return "//select[@id='years']";
            }
        }

        public string TxtAddressFirstname
        {
            get
            {
                return "firstname";
            }
        }

        public string TxtAddressLastname
        {
            get
            {
                return "lastname";
            }
        }

        public string TxtAddressAddress1
        {
            get
            {
                return "address1";
            }
        }

        public string TxtAddressCity
        {
            get
            {
                return "city";
            }
        }

        public string DdlState
        {
            get
            {
                return "id_state";
            }
        }

        public string TxtPostcode
        {
            get
            {
                return "postcode";
            }
        }

        public string DdlCountry
        {
            get
            {
                return "id_country";
            }
        }

        public string TxtMobilePhone
        {
            get
            {
                return "phone_mobile";
            }
        }

        public string TxtAlternativeAddress
        {
            get
            {
                return "alias";
            }
        }

        public string BtnSubmitAccount
        {
            get
            {
                return "submitAccount";
            }
        }

        public string SignInLink
        {
            get
            {
                return "//a[@class='login'][text()[contains(.,'Sign in')]]";
            }
        }

        public string SignOutLink
        {
            get
            {
                return "//a[@class='logout'][text()[contains(.,'Sign out')]]";
            }
        }
    }
}

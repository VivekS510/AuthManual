using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Claims;

namespace AuthManual.BasicAuth
{
    public class BasicAuthAttr : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Login failed");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                //username:password base64 encoded
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] usernamepassword = decodedAuthToken.Split(':');
                string username = usernamepassword[0];
                string password = usernamepassword[1];
                if(ValidateUser.Login(username, password)) 
                {
                   var userDetails = ValidateUser.GetUserDetails(username, password);
                    var identity = new GenericIdentity(username);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Email, userDetails.Email));
                    identity.AddClaim(new Claim("Id" , Convert.ToString(userDetails.Id)));
                    IPrincipal principal = new GenericPrincipal(identity, userDetails.Roles.Split(','));
                    Thread.CurrentPrincipal = principal;
                    if(HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Authorization denied");

                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Invalid Credentials");
                }
            }
            }
        }
    }

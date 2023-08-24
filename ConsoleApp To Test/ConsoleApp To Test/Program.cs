using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System.ServiceModel;
using System.Net.Sockets;
using System.Security.Policy;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Web.Services.Description;
using System.IO;
using System.Windows.Shapes;
using Microsoft.Xrm.Sdk.Query;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //IOrganizationService orgService = GetOrganizationServiceClientSecret("5a0c7c1b-d2cf-46b5-815f-45a91f680b92", "bQO8Q~a4wr6u~cNPVw6DymBQjx5ZE6HsvA6jIabM", "https://singhealthrprmdev2.crm5.dynamics.com");
            //IOrganizationService orgService = GetOrganizationServiceClientSecret("637ebc9d-0e7a-4ef7-a906-f4c30e4b4897", "e7efc0c0-82ee-4003-85ab-ec9a5d335e69", "https://singhealthrprmdev2.crm5.dynamics.com");
            IOrganizationService orgService = GetOrganizationServiceClientSecret("5a0c7c1b-d2cf-46b5-815f-45a91f680b92", "bQO8Q~a4wr6u~cNPVw6DymBQjx5ZE6HsvA6jIabM", "https://org64bde338.crm5.dynamics.com");
            var response = orgService.Execute(new WhoAmIRequest());//To validate the request

            if (response != null)
            {
                Console.WriteLine("Connected to CRM");

                //Your function here              

               
                Console.ReadLine();
            }

        }

        public static IOrganizationService GetOrganizationServiceClientSecret(string clientId, string clientSecret, string organizationUri)
        {
            try
            {
                var conn = new CrmServiceClient($@"AuthType=ClientSecret;url={organizationUri};ClientId={clientId};ClientSecret={clientSecret}");
                return conn.OrganizationWebProxyClient != null ? conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while connecting to CRM " + ex.Message);
                Console.ReadKey();
                return null;
            }
        }
    }

}
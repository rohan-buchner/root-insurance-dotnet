using System.Collections.Generic;
using System.Threading.Tasks;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IPolicyHolder
    {
        Task<PolicyHolderResponse> CreatePolicyHolder(object id, string firstName = null,
            string lastName = null, string email = null,
            string dateOfBirth = null, string cellphone = null);

        Task<IList<PolicyHolderResponse>> ListPolicyHolders();

        Task<PolicyHolderResponse> GetPolicyHolder(string policyHolderId);
        Task<PolicyHolderResponse> UpdatePolicyHolder(string policyHolderId, string email, string cellphone);
        Task<IList<PolicyHolderEvents>> ListPolicyHolderEvents(string policyHolderId);
    }
}
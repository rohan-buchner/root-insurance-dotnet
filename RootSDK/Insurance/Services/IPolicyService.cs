using System.Collections.Generic;
using System.Threading.Tasks;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IPolicyService
    {
        Task<PolicyResponse> IssuePolicy(string applicationId);

        Task<PolicyResponse> AddPolicyBeneficiary(string policyId, object id, string firstName, string lastName,
            int percentage);

        Task<IList<PolicyResponse>> ListPolicies();

        Task<PolicyResponse> GetPolicy(string policyId);
        Task<PolicyResponse> CancelPolicy(string policyId, string reason);
        Task<PolicyResponse> ReplacePolicy(string policyId, string quotePackageId);
        Task<PolicyResponse> UpdatePolicyBillingAmount(string policyId, int billingAmount);

        Task<IList<BeneficiaryResponse>> ListPolicyBeneficiaries(string policyId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Data;

namespace TheThrift.Contracts
{
    public interface ILoanAllocationRepository : IRepositoryBase<LoanAllocation>
    {
        bool CheckAllocation(int loantypeid, string employeeid);
        ICollection<LoanAllocation> GetLoanAllocationByEmployee(string id);
    }
}

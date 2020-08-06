using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Data;
using TheThrift.Repository;

namespace TheThrift.Contracts
{
    public interface ILoanTypeRepository : IRepositoryBase<LoanType>
    {
        ICollection<LoanType> GetEmployeeIdByLeaveType(int id);
    }
}

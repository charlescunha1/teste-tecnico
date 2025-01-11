using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Bank.Domain.Enum;

public enum TransactionType
{
    CREDIT = 1,
    DEBIT = 2,
    AMOUNT_HOLD = 3,
    AMOUNT_RELEASE = 4
}
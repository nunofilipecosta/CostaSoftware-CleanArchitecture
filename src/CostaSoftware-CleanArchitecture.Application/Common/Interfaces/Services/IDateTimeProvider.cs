using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Services;
public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}

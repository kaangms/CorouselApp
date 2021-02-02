using Core.Utilities.Results;
using System.Collections.Generic;

namespace CorouselApp.Busines.Abstract
{
    public interface IOutputService
    {

        public IDataResult<int> MathInputData();
    }
}

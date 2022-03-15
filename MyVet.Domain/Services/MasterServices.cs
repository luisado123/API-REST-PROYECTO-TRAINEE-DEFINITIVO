using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;

using Infraestructure.Entity.Vet;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyVet.Domain.Services
{
    public class MasterServices : IMasterServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MasterServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    

    }
}

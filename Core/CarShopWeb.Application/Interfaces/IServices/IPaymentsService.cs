using CarShopWeb.Application.DTOs.PaymentsDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IPaymentsService
    {
        Task<ResponseModel<List<GetPaymentsDTO>>> GetAll();
        Task<ResponseModel<CreatePaymentsDTO>> CreatePayments(CreatePaymentsDTO createPaymentsDTO);
        Task<ResponseModel<bool>> UpdatePayments(UpdatePaymentsDTO updatePaymentsDTO,int id);
        Task<ResponseModel<bool>> DeletePayments(int id);
        Task<ResponseModel<GetPaymentsDTO>> GetPaymentsById(int id);
        Task<ResponseModel<GetPaymentsDTO>> MaximumPayment();
    }
}

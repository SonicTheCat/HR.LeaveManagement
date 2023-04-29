using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            this.CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            this.CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
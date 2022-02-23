using System;
using Admin_API.ViewModels;
using Admin_API.ViewModels.Deputado;
using Admin_API.ViewModels.Governador;
using Admin_API.ViewModels.Ministro;
using Admin_API.ViewModels.Prefeito;
using Admin_API.ViewModels.Presidente;
using Admin_API.ViewModels.Senador;
using Admin_API.ViewModels.Vereador;
using AutoMapper;
using Projeto_desafio_API_Admin.Entities;

namespace Admin_API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {

            CreateMap<DeputadoViewModel, Deputado>().ReverseMap();
            CreateMap<PutDeputadoViewModel, Deputado>().ReverseMap();
            CreateMap<GetDeputadoViewModel, Deputado>().ReverseMap();

            CreateMap<GovernadorViewModel, Governador>().ReverseMap();
            CreateMap<PutGovernadorViewModel, Governador>().ReverseMap();
            CreateMap<GetGovernadorViewModel, Governador>().ReverseMap();

            CreateMap<MinistroViewModel, Ministro>().ReverseMap();
            CreateMap<PutMinistroViewModel, Ministro>().ReverseMap();
            CreateMap<GetMinistroViewModel, Ministro>().ReverseMap();

            CreateMap<PresidenteViewModel, Presidente>().ReverseMap();
            CreateMap<PutPresidenteViewModel, Presidente>().ReverseMap();
            CreateMap<GetPresidenteViewModel, Presidente>().ReverseMap();

            CreateMap<PrefeitoViewModel, Prefeito>().ReverseMap();
            CreateMap<PutPrefeitoViewModel, Prefeito>().ReverseMap();
            CreateMap<GetPrefeitoViewModel, Prefeito>().ReverseMap();

            CreateMap<SenadorViewModel, Senador>().ReverseMap();
            CreateMap<PutSenadorViewModel, Senador>().ReverseMap();
            CreateMap<GetSenadorViewModel, Senador>().ReverseMap();

            CreateMap<VereadorViewModel, Vereador>().ReverseMap();
            CreateMap<PutVereadorViewModel, Vereador>().ReverseMap();
            CreateMap<GetVereadorViewModel, Vereador>().ReverseMap();
        }
    }
}
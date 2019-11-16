using AutoMapper;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Animal;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Medico;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Prontuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.AutoMapper
{
	public class DominioParaViewModelProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<Medico, MedicoViewModel>();
			Mapper.CreateMap<Animal, AnimalViewModel>();
			Mapper.CreateMap<Prontuario, ProntuarioViewModel>().ReverseMap();
			Mapper.CreateMap<Prontuario, ProntuarioExibicaoViewModel>()
				.ForMember(x => x.AnimalNome, (opt) => 
				{
					opt.MapFrom(src => src.Animal.Nome);
				})
				.ForMember(x => x.MedicoNome, (opt) => 
				{
					opt.MapFrom(src => src.Medico.Nome);
				})
				.ReverseMap();

		}
	}
}
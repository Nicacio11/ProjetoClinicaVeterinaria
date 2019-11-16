using AutoMapper;
using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum;
using Nicacio.ClinicaVeterinaria.Repositorio.EF;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Animal;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Medico;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Prontuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.AutoMapper
{
	public class ViewModelParaDominioProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<MedicoViewModel, Medico>();
			Mapper.CreateMap<AnimalViewModel, Animal>();
				//Mapper.CreateMap<ProntuarioViewModel, Prontuario>()
				//	.ForMember(x => x.Medico, (opt) =>
				//	{
				//		IRepository<Medico, int> repositoryMedico = new RepositoryMedico(new DbContexto());
				//		opt.MapFrom(src => repositoryMedico.GetById(src.IdMedico));
				//	})
				//	.ForMember(x => x.Medico, (opt) =>
				//	{
				//		IRepository<Animal, int> repositoryAnimal = new RepositoryAnimal(new DbContexto());
				//		opt.MapFrom(src => repositoryAnimal.GetById(src.IdAnimal));
				//	});
		}
	}
}
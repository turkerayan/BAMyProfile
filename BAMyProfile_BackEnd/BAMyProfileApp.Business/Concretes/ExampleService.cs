using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class ExampleService : IExampleService
{
    private readonly IExampleRepository _exampleRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public ExampleService(IExampleRepository exampleRepository, IMapper mapper ,IStringLocalizer<MessageResources> localizer)
    {
        _exampleRepository = exampleRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<IResult> CreateAsync(ExampleCreateDTO exampleCreateDTO)
    {
        var hasExample = await _exampleRepository.AnyAsync(x => x.Name.ToLower() == exampleCreateDTO.Name.ToLower());
        if (hasExample) { return new ErrorResult(_localizer[Messages.ExampleAlreadyExists]); }
        var newExample = _mapper.Map<Example>(exampleCreateDTO);
        await _exampleRepository.AddAsync(newExample);
        await _exampleRepository.SaveChangesAsync();
        var exampleDto = _mapper.Map<ExampleDTO>(newExample);
        return new SuccessDataResult<ExampleDTO>(exampleDto, _localizer[Messages.ExampleAddSuccess]);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var example = await _exampleRepository.GetByIdAsync(id);
        if (example == null) { return new ErrorResult(_localizer[Messages.ExampleNotFound]); }
        await _exampleRepository.DeleteAsync(example);
        await _exampleRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.ExampleDeletedSuccess]);
    }

    public async Task<IResult> GetAllAsync()
    {
        var examples = await _exampleRepository.GetAllAsync();
        if (examples.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoExamples]); }
        var exampleListDto = _mapper.Map<List<ExampleListDTO>>(examples);
        return new SuccessDataResult<List<ExampleListDTO>>(exampleListDto, _localizer[Messages.ExampleListedSuccess]);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var example = await _exampleRepository.GetByIdAsync(id);
        if (example == null) { return new ErrorResult(_localizer[Messages.ExampleNotFound]); }
        var exampleDto = _mapper.Map<ExampleDTO>(example);
        return new SuccessDataResult<ExampleDTO>(exampleDto, _localizer[Messages.ExampleFoundSuccess]);
    }

    public async Task<IResult> UpdateAsync(ExampleUpdateDTO exampleUpdateDTO)
    {
        var exampleControl = await _exampleRepository.AnyAsync(x => x.Name.ToLower() == exampleUpdateDTO.Name.ToLower());
        if (exampleControl) { return new ErrorResult(_localizer[Messages.ExampleAlreadyExists]); }
        var example = await _exampleRepository.GetByIdAsync(exampleUpdateDTO.Id);
        if (example == null) { return new ErrorResult(_localizer[Messages.ExampleNotFound]); }
        var updatedExample = _mapper.Map(exampleUpdateDTO, example);
        await _exampleRepository.UpdateAsync(updatedExample);
        await _exampleRepository.SaveChangesAsync();
        return new SuccessDataResult<ExampleDTO>(_mapper.Map<ExampleDTO>(updatedExample), _localizer[Messages.ExampleUpdateSuccess]);

    }
}

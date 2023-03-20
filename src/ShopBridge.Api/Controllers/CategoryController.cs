using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Core.DTOs.Category;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Models;
using ShopBridge.Core.Services;

namespace ShopBridge.Api.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryServices _categoryServices;
    private readonly IMapper _mapper;
    public CategoryController(IMapper mapper, ICategoryServices categoryServices)
    {
        _mapper = mapper;
        _categoryServices = categoryServices;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<CategoryDetailDto>>> AddCategory([FromBody] CategoryAddDto categoryAdd)
    {
        var response = new ResponseModel<CategoryDetailDto>();

        try
        {
            var category = _mapper.Map<Category>(categoryAdd);
            var addedCategory = await _categoryServices.AddCategoryAsync(category);
            response.SetData(_mapper.Map<CategoryDetailDto>(addedCategory));

            if (response.Data == default)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<IEnumerable<CategoryListDetailDto>>>> GetAllCategories()
    {
        var response = new ResponseModel<IEnumerable<CategoryListDetailDto>>();

        try
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();
            response.SetData(_mapper.Map<IEnumerable<CategoryListDetailDto>>(categories));

            if (response.Data == default)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResponseModel<CategoryDetailDto>>> GetCategoryById(int id)
    {
        var response = new ResponseModel<CategoryDetailDto>();

        try
        {
            var foundCategory = await _categoryServices.GetCategoryByIdAsync(id);
            response.SetData(_mapper.Map<CategoryDetailDto>(foundCategory));

            if (response.Data == default)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ResponseModel<CategoryDetailDto>>> RemoveCategoryById(int id)
    {
        var response = new ResponseModel<CategoryDetailDto>();

        try
        {
            var deletedCategory = await _categoryServices.RemoveCategoryByIdAsync(id);
            response.SetData(_mapper.Map<CategoryDetailDto>(deletedCategory));

            if (response.Data == default)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ResponseModel<CategoryDetailDto>>> UpdateCategory([FromBody] CategoryUpdateDto categoryUpdate)
    {
        var response = new ResponseModel<CategoryDetailDto>();

        try
        {
            var category = _mapper.Map<Category>(categoryUpdate);
            var updatedCategory = await _categoryServices.UpdateCategoryAsync(category);
            response.SetData(_mapper.Map<CategoryDetailDto>(updatedCategory));

            if (response.Data == default)
                return NotFound();

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.SetErrorMessage((ex.InnerException ?? ex).Message);
            return BadRequest(response);
        }
    }
}

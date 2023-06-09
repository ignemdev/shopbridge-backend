﻿using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Api.Validators.Product;
using ShopBridge.Core.DTOs.Product;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Models;
using ShopBridge.Core.Services;

namespace ShopBridge.Api.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProductServices _productServices;

    public ProductController(IMapper mapper, IProductServices productServices)
    {
        _mapper = mapper;
        _productServices = productServices;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> AddProduct([FromBody] ProductAddDto productAdd)
    {
        var response = new ResponseModel<ProductDetailDto, ValidationFailure>();
        var validator = new ProductAddDtoValidator();
        var validationResult = await validator.ValidateAsync(productAdd);

        if (!validationResult.IsValid)
        {
            response.SetValidationErrors(validationResult.Errors);
            return BadRequest(response);
        }

        try
        {
            var product = _mapper.Map<Product>(productAdd);
            var addedProduct = await _productServices.AddProductAsync(product);
            response.SetData(_mapper.Map<ProductDetailDto>(addedProduct));

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
    public async Task<ActionResult<ResponseModel<IEnumerable<ProductListDetailDto>>>> GetAllProducts()
    {
        var response = new ResponseModel<IEnumerable<ProductListDetailDto>>();

        try
        {
            var products = await _productServices.GetAllProductsAsync();
            response.SetData(_mapper.Map<IEnumerable<ProductListDetailDto>>(products));

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
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> GetProductById(int id)
    {
        var response = new ResponseModel<ProductDetailDto>();

        try
        {
            var foundProduct = await _productServices.GetProductByIdAsync(id);
            response.SetData(_mapper.Map<ProductDetailDto>(foundProduct));

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
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> RemoveProductById(int id)
    {
        var response = new ResponseModel<ProductDetailDto>();

        try
        {
            var deletedProduct = await _productServices.RemoveProductByIdAsync(id);
            response.SetData(_mapper.Map<ProductDetailDto>(deletedProduct));

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
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> UpdateProduct([FromBody] ProductUpdateDto productUpdate)
    {
        var response = new ResponseModel<ProductDetailDto, ValidationFailure>();
        var validator = new ProductUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(productUpdate);

        if (!validationResult.IsValid)
        {
            response.SetValidationErrors(validationResult.Errors);
            return BadRequest(response);
        }

        try
        {
            var product = _mapper.Map<Product>(productUpdate);
            var updatedProduct = await _productServices.UpdateProductAsync(product);
            response.SetData(_mapper.Map<ProductDetailDto>(updatedProduct));

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

    [HttpPost("{id:int}/categories")]
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> AddProductCategories(int id, [FromBody] IEnumerable<int> categoriesIds)
    {
        var response = new ResponseModel<ProductDetailDto>();

        try
        {
            var product = await _productServices.AddProductCategoriesAsync(id, categoriesIds);
            response.SetData(_mapper.Map<ProductDetailDto>(product));

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

    [HttpPut("addstock")]
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> AddProductStock([FromBody] ProductStockUpdateDto productStockUpdate)
    {
        var response = new ResponseModel<ProductDetailDto, ValidationFailure>();
        var validator = new ProductStockUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(productStockUpdate);

        if (!validationResult.IsValid)
        {
            response.SetValidationErrors(validationResult.Errors);
            return BadRequest(response);
        }

        try
        {
            var product = _mapper.Map<Product>(productStockUpdate);
            var updatedProduct = await _productServices.AddProductStockAsync(product);
            response.SetData(_mapper.Map<ProductDetailDto>(updatedProduct));

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

    [HttpPut("reducestock")]
    public async Task<ActionResult<ResponseModel<ProductDetailDto>>> ReduceProductStock([FromBody] ProductStockUpdateDto productStockUpdate)
    {
        var response = new ResponseModel<ProductDetailDto, ValidationFailure>();
        var validator = new ProductStockUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(productStockUpdate);

        if (!validationResult.IsValid)
        {
            response.SetValidationErrors(validationResult.Errors);
            return BadRequest(response);
        }

        try
        {
            var product = _mapper.Map<Product>(productStockUpdate);
            var updatedProduct = await _productServices.ReduceProductStockAsync(product);
            response.SetData(_mapper.Map<ProductDetailDto>(updatedProduct));

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

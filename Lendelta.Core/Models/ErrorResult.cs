﻿using LENDELTA.Common.Models;
using LENDELTA.Core.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace LENDELTA.Core.Models
{
    public class ErrorMessage
    {
        public string Message { get; set; }

        public string Property { get; set; }
    }

    public static class ErrorResult
    {
        public static ErrorViewModel GetResult(OperationResult result, ErrorCodes code = ErrorCodes.InternalServerError)
        {
            return new ErrorViewModel
                   {
                       Errors = result.Errors
                                      .Select(x => new ErrorMessage
                                                   {
                                                       Message = x,
                                                       Property = string.Empty
                                                   })
                                      .ToList(),
                       Code = code
                   };
        }

        internal static ErrorViewModel GetResult<T>(OperationResult<T> result, ErrorCodes code = ErrorCodes.InternalServerError)
        {
            return new ErrorViewModel
                   {
                       Errors = result.Errors
                                      .Select(x => new ErrorMessage
                                                   {
                                                       Message = x,
                                                       Property = string.Empty
                                                   })
                                      .ToList(),
                       Code = code
                   };
        }

        public static ErrorViewModel GetResult(List<string> errors, ErrorCodes code = ErrorCodes.InternalServerError)
        {
            return new ErrorViewModel
                   {
                       Errors = errors.Select(x => new ErrorMessage
                                                   {
                                                       Message = x,
                                                       Property = string.Empty
                                                   })
                                      .ToList(),
                       Code = code
                   };
        }

        public static ErrorViewModel GetResult(string message, ErrorCodes code = ErrorCodes.InternalServerError, string property = null)
        {
            return new ErrorViewModel
                   {
                       Errors = new[]
                                {
                                    new ErrorMessage
                                    {
                                        Message = message,
                                        Property = string.Empty //property
                                    }
                                },
                       Code = code
                   };
        }

        public static ErrorViewModel GetResult(ModelStateDictionary modelState)
        {
            var errors = new List<ErrorMessage>();

            foreach (var entry in modelState)
            {
                errors.AddRange(entry.Value
                                     .Errors
                                     .Select(x => new ErrorMessage
                                                  {
                                                      Message = x.ErrorMessage,
                                                      Property = string.Empty //entry.Key
                                                  }));
            }

            return new ErrorViewModel
                   {
                       Errors = errors,
                       Code = ErrorCodes.ValidationError
                   };
        }

        public static ErrorViewModel GetResult(IdentityResult identityResult)
        {
            return new ErrorViewModel
                   {
                       Errors = identityResult.Errors
                                              .Select(x => new ErrorMessage
                                                           {
                                                               Message = x.Description,
                                                               Property = string.Empty //string.Empty
                                                           }),
                       Code = ErrorCodes.InternalServerError
                   };
        }
    }
}

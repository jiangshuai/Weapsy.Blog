﻿using Weapsy.Blog.Domain.Blogs.Rules;
using Weapsy.Blog.Domain.Posts.Commands;
using Weapsy.Blog.Domain.Posts.Rules;

namespace Weapsy.Blog.Domain.Posts.CommandHandlers.Validators
{
    public class UpdatePostValidator : PostDetailsValidatorBase<UpdatePost>
    {
        public UpdatePostValidator(IPostRules postRules, IBlogRules blogRules) : base(postRules, blogRules)
        {
            ValidateTitle();
            ValidateSlug();
            ValidateExcerpt();
            ValidateContent();
        }
    }
}

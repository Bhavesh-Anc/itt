@model JobApplicationPortal.Areas.Identity.Pages.Account.RegisterModel
@{
    ViewData["Title"] = "Register";
}

<div class="row">
    <div class="col-md-6 offset-md-3">
        <form asp-route-returnUrl="@Model.ReturnUrl" method="post">
            <h4>Create a new account.</h4>
            <hr />
            <div asp-validation-summary="All" class="text-danger"></div>
            
            <div class="form-group">
                <label asp-for="Input.FirstName"></label>
                <input asp-for="Input.FirstName" class="form-control" />
                <span asp-validation-for="Input.FirstName" class="text-danger"></span>
            </div>

            <div class="form-group">
                <label asp-for="Input.LastName"></label>
                <input asp-for="Input.LastName" class="form-control" />
                <span asp-validation-for="Input.LastName" class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <label asp-for="Input.Email"></label>
                <input asp-for="Input.Email" class="form-control" />
                <span asp-validation-for="Input.Email" class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <label asp-for="Input.Password"></label>
                <input asp-for="Input.Password" class="form-control" />
                <span asp-validation-for="Input.Password" class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <label asp-for="Input.ConfirmPassword"></label>
                <input asp-for="Input.ConfirmPassword" class="form-control" />
                <span asp-validation-for="Input.ConfirmPassword" class="text-danger"></span>
            </div>
            
            <div class="form-group form-check">
                <input type="checkbox" asp-for="IsRecruiter" class="form-check-input" />
                <label class="form-check-label" asp-for="IsRecruiter">I am a recruiter</label>
            </div>
            
            <button type="submit" class="btn btn-primary">Register</button>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
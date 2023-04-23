using Microsoft.AspNetCore.Mvc.Rendering;

namespace Counseling.MVC.Methods
{
    public static class GeneralMethods
    {
        //select gender list
        public static List<SelectListItem> GenderList(string gender = null)
        {
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Cinsiyet Seçiniz",
                Selected = gender == null ? true : false,
                Disabled = true

            });
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = gender == "Kadın" ? true : false,
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = gender == "Erkek" ? true : false
            });
            return genderList;
        }
    }
}

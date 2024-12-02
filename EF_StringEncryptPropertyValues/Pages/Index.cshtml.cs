using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.Extensions.Options;

using Serilog;

using MiscSettings = EF_StringEncryptPropertyValues.Models.MiscSettings;

namespace EF_StringEncryptPropertyValues.Pages;
public class IndexModel : PageModel
{
    public List<SelectListItem> Options { get; set; }
    
    [BindProperty]
    public string SelectedItem { get; set; }

    public readonly IOptions<List<MiscSettings>> MiscSettingsList;

    public IndexModel(IOptions<List<MiscSettings>> options)
    {
        MiscSettingsList = options;

        var list = MiscSettingsList.Value.Select(x => new MiscSettings()
        {
            Name = x.Name, 
            TheEnum = x.TheEnum
        }).ToList();
        
        foreach (var item in list)
        {
            Log.Information("Name {P1} Enum {P2}", item.Name, item.TheEnum);
        }

        Options = MiscSettingsList.Value.Select(item => new SelectListItem()
        {
            Value = item.TheEnum.ToString(),
            Text = item.Name
        }).ToList();


    }
}



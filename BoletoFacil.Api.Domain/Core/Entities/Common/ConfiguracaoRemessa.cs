using BoletoFacil.Domain.Core.Entities.Configurations;
using BoletoFacil.Domain.Core.Entities.Dimension;

namespace BoletoFacil.Domain.Core.Entities.Common;

public class Remessa
{
    public Guid RemessaId { get; set; }


    public LayoutConfiguration? Layout { get; set; }
    public required int LayoutConfigurationId { get; set; }  
    public DimBanco? DimBanco { get; set; }      
    public required int DimBancoId { get; set; }


    public Header? Header { get; set; }
    public Guid HeaderId { get; set; }

    //public string ArquivoTXT { get; set; }
}
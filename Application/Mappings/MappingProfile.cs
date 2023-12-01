using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProdutoRequest, Produto>();
        CreateMap<Produto, ProdutoResponse>();
        CreateMap<ProdutoResponse, Produto>();

        CreateMap<PedidoRequest, Pedido>();
        CreateMap<PedidoRequest, PedidoDTO>();

        CreateMap<PedidoDTO, Pedido>();

        CreateMap<ItensPedidoDTO, ItensPedido>();
        CreateMap<ItensPedido, ItensPedidoDTO>();

        CreateMap<ItensPedido, ItensPedidoDTO>()
            .ForMember(x => x.Id, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(x => x.IdProduto, cfg => cfg.MapFrom(src => src.ProdutoId))
            .ForMember(x => x.Quantidade, cfg => cfg.MapFrom(src => src.Quantidade));

        CreateMap<ItensPedidoDTO, ItensPedido>()
            .ForMember(x => x.Id, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(x => x.ProdutoId, cfg => cfg.MapFrom(src => src.IdProduto))
            .ForMember(x => x.Quantidade, cfg => cfg.MapFrom(src => src.Quantidade));

        CreateMap<Pedido, PedidoResponse>();
        CreateMap<PedidoDTO, PedidoResponse>();
    }
}
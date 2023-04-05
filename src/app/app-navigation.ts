export const navigation = [
  {
    text: 'Home',
    path: './home',
    icon: 'home',
  },
  {
    text: 'Clientes',
    icon: 'user',
    items: [
      {
        text: 'listado',
        path: './clientes/lista',
      },
    ],
  },
  {
    text: 'inventario',
    icon: 'export',
    items: [
      {
        text: 'Productos',
        path: './inventario/listado',
      },
      {
        text: 'Bodegas',
        path: './inventario/bodegas',
      },
      {
        text: 'Impuestos',
        path: './inventario/impuestos',
      },
      {
        text: 'Marcas',
        path: './inventario/marcas',
      },

      {
        text: 'Categorias',
        path: './inventario/categorias',
      },
      {
        text: 'Descuentos',
        path: './inventario/descuentos',
      },
    ],
  },
  {
    text: 'Facturacion',
    icon: 'cart',
    items: [
      {
        text: 'POS',
        path: './facturacion/POS',
      },
      {
        text: 'Historico Ventas',
        path: './facturacion/listado',
      },
    ],
  },
];

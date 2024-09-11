# Respuestas
## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
Considero que las relaciones Pedidos - Cliente y Cadetería - Cadete son de composición. La primera lo indica el enunciado Si se elimina un pedido entonces el cliente tiene que eliminarse también , y la segunda debido a que un cadete no puede existir sin pertenecer a una cadetería.
La relacion Cadete-Pedidos la considero de Argegación porque los Pedidos pueden ser reasignados o existir independientemente de un Cadete.

## ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
Cadetería:
- AgregarCadete
- EliminarCadete
- AsignarPedidoACadete
- ReasignarPedido
- EliminarPedido

Cadete: 
- AgregarPedido
- EliminarPedido
- PedidosEntregados

## Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados
Cadeteria: Todos públicos, excepto ListadoCadetes, Cadete: Todos publicos, exepto ListadoPedidos, Pedidos: Todos públicos, excepto Cliente, Cliente: Todos públicos.



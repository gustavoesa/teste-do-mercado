<html>
	<head>
		<title>Consultas</title>
		<style type="text/css">
			table, tr, td 
			{
				border: 1px solid black;
			}
			table 
			{
				border-collapse: collapse;
				background-color: white;
				text-align: center;
				width: 50%;
			}
		</style>
		<?php
			include 'conecta.php'; 
			
			$nome_mercadoria = $_POST["nomemercadoria"];

			if(isset($nome_mercadoria))
			{
				$tipo_mercadoria = $_POST["tipomercadoria"];
				$qtd = $_POST["quantidade"];
				$preco = $_POST["preco"];
				$tipo_negocio = $_POST["tiponegocio"];
				$preco_total = $qtd * $preco;

				$grava = "INSERT INTO comercio(cod_mercadoria, tipo_mercadoria, nome_mercadoria, qtd, preco, tipo_negocio, preco_total) VALUES ('', '$tipo_mercadoria', '$nome_mercadoria', '$qtd', '$preco', '$tipo_negocio', '$preco_total')";
				$gravacao = mysql_query($grava);
			}
				$consulta = "SELECT * FROM comercio";
				$consultar = mysql_query($consulta);
		?>
	</head>
<body bgcolor="lightblue">
	<h1 align="center">Histórico</h1>
	<hr> 
	<table align=center>
		<tr>
			<td><b>Código Mercadoria</td>
			<td><b>Tipo da Mercadoria</td>
			<td><b>Nome da Mercadoria</td>
			<td><b>Quantidade</td>
			<td><b>Valor p/ Un.</td>
			<td><b>Tipo do Negócio</td>
			<td><b>Valor Total</td>
		</tr>

		<?php 
			while($l = mysql_fetch_array($consultar))
			{
				$codmercadoria = $l["cod_mercadoria"];
				$tipomercadoria = $l["tipo_mercadoria"];
				$nomeM = $l["nome_mercadoria"];
				$quantidade = $l["qtd"];
				$valor = $l["preco"];
				$valorF = number_format($valor, 2, ',', '.');
				$tiponegocio = $l["tipo_negocio"];
				$valorT = $l["preco_total"];
				$valorTF = number_format($valorT, 2, ',', '.');
				
				if($tipomercadoria == 1)
					$tipomercadoria = "Produtos de Limpeza";
				else
					$tipomercadoria = "Material de Escritório";

				if($tiponegocio = 1)
					$tiponegocio = "Compra";
				else
					$tiponegocio = "Venda";

				echo "<tr>";
					echo "<td> $codmercadoria</td>";
					echo "<td> $tipomercadoria</td>";
					echo "<td> $nomeM</td>";
					echo "<td> $quantidade</td>";
					echo "<td>R$ $valorF</td>";
					echo "<td> $tiponegocio</td>";
					echo "<td>R$ $valorTF";
			}
		?>
	</table>
	<center>
		<a href="index.php"><h3>Voltar</h3></a><br>
	</center>
</body>
</html>
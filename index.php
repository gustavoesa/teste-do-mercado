<html>
<head>
	<title>Teste-do-Mercado</title>
	<style type="text/css">
		select{ width: 150px; }
		.btn{ width: 100px; }
		input:required:invalid {}
		input:required:valid {}
		p {font-weight: bold;}
	</style>
	<?php
		include 'conecta.php';

		$mercadoria = "SELECT * FROM tipos";
		$tipomercadoria = mysql_query($mercadoria);

		$negocio = "SELECT * FROM tipo_negocio";
		$tiponegocio = mysql_query($negocio);
	?>
	<script language="JavaScript">
		function valida(){
			if(form1.nomemercadoria.value == ""){
				alert("Preencha o Nome da Mercadoria!");
				form1.nomemercadoria.select();
			}
			else
				if(form1.quantidade.value == ""){
					alert("Preencha a Quantidade!");
					form1.quantidade.select();
				}				
				else
					if(form1.preco.value == ""){
						alert("Preencha o Preço!");
						form1.preco.select();
					}
					else
						if(isNaN(form1.quantidade.value)){
							alert("Apenas Números!");
							form1.quantidade.select();
							return false;
						}
						else
							form1.submit();
		}
	</script>
</head>
<body bgcolor="lightblue">
	<center>
		<h1>Teste do Mercado</h1>
	</center>
	<form name="form1" method="post" action="grava.php">
		<b>
		<center>
			<table border=0>
				<hr>
				<tr>
					<td><p>Nome da Mercadoria:</td>
					<td><input type="text" name="nomemercadoria" required="required"></td>
					<td>
						<p>Tipo de Negócio:
						<select name="tiponegocio">
							<?php while ($l1 = mysql_fetch_array($tiponegocio)){ echo "<option value=$l1[id_negocio]>$l1[desc_negocio]";} ?>
						</select>
					</td>
				<tr>
					<td><p>Quantidade: </td>
					<td><input type="text" name="quantidade" pattern="[0-9]+$" required="required" required oninvalid="setCustomValidity('Somente Números')"></td>
					<td rowspan="2">
						<p>Tipo Mercadoria: 
							<select name="tipomercadoria">
								<?php while ($l = mysql_fetch_array($tipomercadoria)) {echo "<option value=$l[tipo_mercadoria]>$l[desc_mercadoria]</option>";} ?>
							</select>
					</td>
				<tr>
					<td><p>Preço:</td>
					<td><input type="text" name="preco" value="" required="required" required oninvalid="setCustomValidity('Somente Números')" ></td>
			</table>

			<hr>
		
				<input type="submit" name="submit" value="Enviar" class="btn" onClick="valida()">
				<a href="grava.php">Registros</a>
		</center>
	</form>
		</b>
</body>
</html>
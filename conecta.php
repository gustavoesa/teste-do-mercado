<?php
		error_reporting(0);
		ini_set(“display_errors”, 0 );
		echo "<html xmlns=http://www.w3.org/1999/xhtml lang=pt-br xml:lang=pt-br>";
		echo "<meta http-equiv=Content-Type content=text/html; charset=utf-8 />";
		$host = "localhost";
		$banco = "valemobi";
		$user = "root";
		$senha = "";

		$con = mysql_connect($host, $user, $senha) or die("Erro conexão");

		mysql_select_db($banco, $con) or die("Erro BD");

	?>
package br.com.meucalhambeque02.controllers;

import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import br.com.meucalhambeque02.models.Login;

@RestController
@RequestMapping("autenticacao/")
public class LoginController {
	@PostMapping("/login")
	public ResponseEntity<Boolean> login(@RequestBody Login login) {
		Boolean autenticado = (login.getNome().equals("everton") && login.getSenha().equals("1234"));
		return new ResponseEntity<Boolean>(autenticado, new HttpHeaders(), HttpStatus.OK);
	}
}

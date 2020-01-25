package br.com.meucalhambeque02.controllers;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import br.com.meucalhambeque02.models.Cliente;
import br.com.meucalhambeque02.dao.ClienteRepository;

@RestController
@RequestMapping("clientes/")
public class ClienteController {
	@Autowired
	ClienteRepository repository;

	@PostMapping("/save")
	@Transactional
	public ResponseEntity<Boolean> saveCliente(@RequestBody Cliente cliente){
		if (cliente.getClienteID() == null)
			cliente.setClienteID(UUID.randomUUID().toString());
		cliente.setSincronizado(true);
		repository.save(cliente);
		
		return new ResponseEntity<Boolean>(true, new HttpHeaders(), HttpStatus.OK);
	}

	@RequestMapping("/getAll")
	public List<Cliente> selectAll() {
		List<Cliente> list = new ArrayList<Cliente>();
		for (Cliente cliente : repository.findAll()) {
			list.add(cliente);
		}
		return list;
	}
	
	@RequestMapping("/findbyid")
	public Cliente findById(@RequestParam("id") String id){
		Cliente result;
		result = repository.findOne(id);;
		return result;
	}
	
	@RequestMapping("/deleteAll")
	public ResponseEntity<Boolean> deleteAll() {
		List<Cliente> clientes = selectAll();
		for (Cliente cliente : clientes) {
			repository.delete(cliente);
		}
		return new ResponseEntity<Boolean>(true, new HttpHeaders(), HttpStatus.OK);
	}
}

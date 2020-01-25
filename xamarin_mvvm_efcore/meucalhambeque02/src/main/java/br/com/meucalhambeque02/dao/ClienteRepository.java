package br.com.meucalhambeque02.dao;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import br.com.meucalhambeque02.models.Cliente;

@Repository
public interface ClienteRepository extends CrudRepository<Cliente, String> {
}
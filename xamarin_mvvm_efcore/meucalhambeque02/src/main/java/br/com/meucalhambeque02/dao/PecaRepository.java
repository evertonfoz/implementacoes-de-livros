package br.com.meucalhambeque02.dao;

import java.util.UUID;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import br.com.meucalhambeque02.models.Peca;

@Repository
public interface PecaRepository extends CrudRepository<Peca, UUID> {
}

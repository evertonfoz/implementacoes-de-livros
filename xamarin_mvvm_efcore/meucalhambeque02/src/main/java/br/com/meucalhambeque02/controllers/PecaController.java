package br.com.meucalhambeque02.controllers;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import javax.servlet.ServletContext;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import br.com.meucalhambeque02.dao.PecaRepository;
import br.com.meucalhambeque02.models.Cliente;
import br.com.meucalhambeque02.models.Peca;

@RestController
@RequestMapping("pecas/")
public class PecaController {
	@Autowired
	PecaRepository repository;
	
	@Autowired
	ServletContext context;
	
	@PostMapping("/savecomimagem")
	@Transactional
	public ResponseEntity<String> saveComImagem(@ModelAttribute Peca peca){
		if (peca.getPecaID() == null)
			peca.setPecaID(UUID.randomUUID());
		peca.setSincronizado(true);

		String nomeArquivo = null;
		if (peca.getArquivo() != null && peca.getCaminhoImagem() != null && !peca.getCaminhoImagem().startsWith("http")) {
            nomeArquivo = (peca.getCaminhoImagem().lastIndexOf("/") > 0) ? peca.getCaminhoImagem().substring(peca.getCaminhoImagem().lastIndexOf("/") + 1) : peca.getCaminhoImagem();
			String realPathToUploads = context.getRealPath("imagensPecas") + File.separator + nomeArquivo;
			byte[] bytes;
			try {
				bytes = peca.getArquivo().getBytes();
				peca.setArquivoEmBytes(bytes);
			    Path path = Paths.get(realPathToUploads);
			    Files.write(path, bytes);
			} catch (IOException e) {
				return new ResponseEntity<String>(e.getMessage(), new HttpHeaders(), HttpStatus.OK);
			}
		}

		if (nomeArquivo != null && !peca.getCaminhoImagem().startsWith("http"))
			peca.setCaminhoImagem("https://meucalhambeque02.herokuapp.com/imagensPecas/" + nomeArquivo);
		repository.save(peca);

		return new ResponseEntity<String>(peca.getCaminhoImagem(), new HttpHeaders(), HttpStatus.OK);
	}

	@PostMapping("/saveimagemembytes")
	@Transactional
	public ResponseEntity<String> saveComImagemEmBytes(@ModelAttribute Peca peca){
		if (peca.getPecaID() == null)
			peca.setPecaID(UUID.randomUUID());
		peca.setSincronizado(true);

		if (peca.getArquivo() != null) {
			try {
				byte[] bytes = peca.getArquivo().getBytes();
				peca.setArquivoEmBytes(bytes);
				peca.setCaminhoImagem(null);
			} catch (IOException e) {
				return new ResponseEntity<String>(e.getMessage(), new HttpHeaders(), HttpStatus.OK);
			}
		} else {
			Peca pecaJaGravada = repository.findOne(peca.getPecaID());
			if (pecaJaGravada != null)
				peca.setArquivoEmBytes(pecaJaGravada.getArquivoEmBytes());
		}

		repository.save(peca);

		return new ResponseEntity<String>("true", new HttpHeaders(), HttpStatus.OK);
	}

	@PostMapping("/savesemimagem")
	@Transactional
	public ResponseEntity<String> saveSemImagem(@RequestBody Peca peca){
		if (peca.getPecaID() == null)
			peca.setPecaID(UUID.randomUUID());
		peca.setSincronizado(true);
		repository.save(peca);
		return new ResponseEntity<String>("true", new HttpHeaders(), HttpStatus.OK);
	}

	@RequestMapping("/findAll")
	public ResponseEntity<List<Peca>> findAll() {
		List<Peca> list =  new ArrayList<Peca>();
		repository.findAll().forEach((peca) -> {
			peca.setArquivoEmBytes(null);
			list.add(peca);
		});
		//repository.findAll().forEach(list::add);
		return new ResponseEntity<List<Peca>>(list, new HttpHeaders(), HttpStatus.OK);
	}
	
	@PostMapping("/removebyid")
	@Transactional
	public ResponseEntity<String> removeById(@RequestBody UUID id){
		repository.delete(id);
		return new ResponseEntity<String>("true", new HttpHeaders(), HttpStatus.OK);
	}
	
	@RequestMapping("/findbyid")
	public ResponseEntity<Peca> findById(@RequestParam("id") UUID id){
		Peca p = repository.findOne(id);
		p.setArquivoEmBytes(null);
		return new ResponseEntity<Peca>(p, new HttpHeaders(), HttpStatus.OK);
	}
	
	@GetMapping( value = "/getimagem/{id}", produces = MediaType.IMAGE_JPEG_VALUE )
	public @ResponseBody byte[] getImagemComoBytes(@PathVariable(value="id") UUID id) throws IOException {
	    return repository.findOne(id).getArquivoEmBytes();
	}
}
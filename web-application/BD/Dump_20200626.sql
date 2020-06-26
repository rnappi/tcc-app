CREATE DATABASE  IF NOT EXISTS `questionarios` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `questionarios`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: questionarios
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alternativas`
--

DROP TABLE IF EXISTS `alternativas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alternativas` (
  `id_Alternativa` int NOT NULL AUTO_INCREMENT,
  `id_Pergunta` int NOT NULL,
  `Descricao` varchar(200) NOT NULL,
  `Alternativa_Correta` tinyint DEFAULT '0',
  PRIMARY KEY (`id_Alternativa`),
  UNIQUE KEY `id_Alternativa_UNIQUE` (`id_Alternativa`),
  KEY `fk_alternativa_pergunta_idx` (`id_Pergunta`),
  CONSTRAINT `fk_alternativa_pergunta` FOREIGN KEY (`id_Pergunta`) REFERENCES `perguntas` (`id_Pergunta`)
) ENGINE=InnoDB AUTO_INCREMENT=157 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alternativas`
--

LOCK TABLES `alternativas` WRITE;
/*!40000 ALTER TABLE `alternativas` DISABLE KEYS */;
INSERT INTO `alternativas` VALUES (1,1,'Vossa Excelência Reverendíssima.',0),(2,1,'Vossa Santidade.',0),(3,1,'Vossa Eminência.',1),(4,1,'Vossa Magnificência.',0),(5,2,'Espera-se que, no Brasil, Sua Santidade, o Papa Francisco, seja recebido, com o devido respeito, pelos jovens.',1),(6,2,'O advogado assim se pronunciou perante o juiz: - Peço a Vossa Senhoria que ouça o depoimento desta nova testemunha.',0),(7,2,'Vossa Majestade, a princesa da Inglaterra, foi homenageada por ocasião do seu aniversário.',0),(8,2,'Refiro-me ao Ilustríssimo Senhor, Cardeal de Brasília, ao enviar-lhe as notícias do Conclave.',0),(9,3,'Reitores de universidades.',0),(10,3,'Sacerdotes em geral.',1),(11,3,'Papas.',0),(12,3,'Altas autoridades.',0),(13,4,'Príncipes.',0),(14,4,'Imperadores.',0),(15,4,'Cardeais.',1),(16,4,'Reitores de universidades.',0),(17,5,'Aqueles meninos são do morro.',1),(18,5,'Lá que moram meus amigos, meus irmãos.',1),(19,5,'Eu gosto disso.',0),(20,5,'Esse é o morro.',0),(21,6,'Nosso – deste – que.',0),(22,6,'Quem – essa – seu.',0),(23,6,'Nosso – seu – que.',0),(24,6,'Nosso – seu – suas.',1),(25,7,'Pegou os processos com ele.',0),(26,7,'Você precisa aprender as novas regras.',0),(27,7,'Nossa família veio assim que soube.',1),(28,7,'O mal foi este: criar os filhos como príncipes.',0),(29,8,'seus – pronome substantivo',0),(30,8,'seus – pronome adjetivo; meus – pronome substantivo',1),(31,8,'meus – pronome adjetivo',0),(32,8,'seus – pronome adjetivo',0),(33,9,'Dois pronomes possessivos e dois pronomes pessoais.',0),(34,9,'Um pronome pessoal, um pronome possessivo e dois pronomes relativos',1),(35,9,'Dois pronomes pessoais e dois pronomes relativos',0),(36,9,'Um pronome pessoal, um pronome possessivo, um pronome relativo e um pronome interrogativo',0),(37,10,'O que fazes não está correto.',0),(38,10,'A vida que levo não é fácil.',0),(39,10,'O caminho por que passei é um atalho.',0),(40,10,'Temos que trabalhar aos sábados.',1),(41,11,'O livro a que eu me refiro é Estrela da manhã, do Manuel Bandeira.',0),(42,11,'Ela é uma pessoa de cuja idoneidade ninguém duvida.',0),(43,11,'O homem de cujo lhe falei ontem é este.',1),(44,11,'O tribunal do juri perante o qual o réu foi condenado foi implacável.',0),(45,12,'1, 2, 4',0),(46,12,'2, 4, 6',0),(47,12,'3, 4 , 5',0),(48,12,'2, 3, 4',1),(49,13,'Essas vitórias pouco importam; alcançaram-nas os que tinham mais dinheiro.',1),(50,13,'Entregaram-me a encomenda ontem, resta agora a vocês oferecerem-na ao chefe.',0),(51,13,'Ele me evitava constantemente!... Ter-lhe-iam falado a meu respeito?Vossa Majestade, a princesa da Inglaterra, foi homenageada por ocasião do seu aniversário.',0),(52,13,'Estamos nos sentido desolados: temos prevenido-o várias vezes e ele não nos escuta.',0),(53,14,'Ele entregou um texto para mim corrigir.',1),(54,14,'Para mim, a leitura está fácil.',0),(55,14,'Isto é para eu fazer agora.',0),(56,14,'Não saia sem mim. ',0),(57,15,'Este é um problema para mim resolver.',0),(58,15,'Entre eu e tu não há mais nada.',1),(59,15,'A questão deve ser resolvida por eu e você.',0),(60,15,'Para mim, viajar de avião é um suplício. ',0),(61,16,'Se encontrá-lo, não lhe diga que viu-me.',0),(62,16,'Se o encontrar, não lhe diga que me viu.',0),(63,16,'Se o encontrar, não lhe diga que viu-me.',1),(64,16,'Se encontrá-lo, não diga-lhe que me viu.',0),(65,17,'Vossa Senhoria.',1),(66,17,'Vossa Santidade.',1),(67,17,'Vossa Excelência.',0),(68,17,'Vossa Magnificência.',0),(69,18,'Os Reitores das Universidades recebem o título de Vossa Magnificência.',0),(70,18,'Sua Excelência, o Senhor Ministro, não compareceu à reunião.',0),(71,18,'Senhor Deputado, peço a Vossa Excelência que conclua a sua oração.',0),(72,18,'Sua Eminência, o Papa Paulo VI, assistiu à solenidade.',1),(73,19,'Papa ............... V. As',0),(74,19,'Juiz ................. V. Ema',0),(75,19,'Cardeal ........... V.M.',1),(76,19,'Reitor ............... V. Maga',0),(77,20,'Espera-se que, no Brasil, Sua Santidade, o Papa Francisco, seja recebido, com o devido respeito, pelos jovens.',0),(78,20,'O advogado assim se pronunciou perante o juiz: - Peço a Vossa Senhoria que ouça o depoimento desta nova testemunha.',1),(79,20,'Vossa Majestade, a princesa da Inglaterra, foi homenageada por ocasião do seu aniversário.',0),(80,20,'Refiro-me ao Ilustríssimo Senhor, Cardeal de Brasília, ao enviar-lhe as notícias do Conclave.',0),(81,21,'Não sei onde eles estão.',0),(82,21,'Onde estás que não respondes?',1),(83,21,'A instituição onde estudo é a UEPG.',0),(84,21,'Ele me deixou onde está a catedral. ',0),(85,22,'O que queres não está aqui.',0),(86,22,'Temos que estudar mais.',0),(87,22,'A estrada por que passei é estreita.',0),(88,22,'A prova que faço não é difícil.',1),(89,23,'1, 2, 4',0),(90,23,'2, 4, 6',0),(91,23,'3, 4 , 5',1),(92,23,'2, 3, 4',0),(93,24,'dois pronomes possessivos e dois pronomes pessoais.',0),(94,24,'um pronome pessoal, um pronome possessivo e dois pronomes relativos.',0),(95,24,'dois pronomes pessoais e dois pronomes relativos.',0),(96,24,'um pronome pessoal, um pronome possessivo, um pronome relativo e um pronome interrogativo.',1),(97,25,'Correto',1),(98,25,'Errado',0),(99,26,'Correto',0),(100,26,'Errado',1),(101,27,'Errado',0),(102,27,'Correto',1),(103,28,'Correto',0),(104,28,'Errado',1),(105,29,'Correto',1),(106,29,'Errado',0),(107,30,'Correto',1),(108,30,'Errado',0),(109,31,'Correto',1),(110,31,'Errado',0),(111,32,'Correto',1),(112,32,'Errado',0),(113,33,'Correto',0),(114,33,'Errado',1),(115,34,'Correto',0),(116,34,'Errado',1),(117,35,'3',0),(118,35,'5',1),(119,35,'7',0),(120,35,'9',0),(121,36,'5,3 L.',0),(122,36,'6,0 L.',0),(123,36,'6,3 L.',1),(124,36,'7,0 L.',0),(125,37,'9',0),(126,37,'18',1),(127,37,'24',0),(128,37,'36',0),(129,38,'0.02',0),(130,38,'0.10',0),(131,38,'0.20',1),(132,38,'2.10',0),(133,39,'731',1),(134,39,'730',0),(135,39,'732',0),(136,39,'756',0),(137,40,'224 patas',1),(138,40,'324 patas',0),(139,40,'524 patas',0),(140,40,'124 patas',0),(141,41,'128',1),(142,41,'512',0),(143,41,'256',0),(144,41,'72',0),(145,42,'15',0),(146,42,'25',0),(147,42,'35',1),(148,42,'45',0),(149,43,'50',1),(150,43,'96',0),(151,43,'35',0),(152,43,'18',0),(153,44,'2 semanas',0),(154,44,'4 semanas',0),(155,44,'8 semanas',1),(156,44,'5 semanas',0);
/*!40000 ALTER TABLE `alternativas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunos`
--

DROP TABLE IF EXISTS `alunos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunos` (
  `id_Aluno` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `Usuario` varchar(150) DEFAULT NULL,
  `Senha` varchar(50) DEFAULT NULL,
  `Data_Cadastro` datetime DEFAULT NULL,
  `Data_Ultima_Atualizacao` datetime DEFAULT NULL,
  PRIMARY KEY (`id_Aluno`),
  UNIQUE KEY `id_Aluno_UNIQUE` (`id_Aluno`),
  UNIQUE KEY `Login_UNIQUE` (`Usuario`),
  UNIQUE KEY `Email_UNIQUE` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunos`
--

LOCK TABLES `alunos` WRITE;
/*!40000 ALTER TABLE `alunos` DISABLE KEYS */;
INSERT INTO `alunos` VALUES (1,'Aluno 1','aluno1@email.edu.br','aluno1','aluno123','2020-05-29 15:06:48','2020-05-29 15:06:48'),(2,'Aluno 2','aluno2@email.edu.br','aluno2','aluno123','2020-06-09 15:06:48','2020-06-09 15:06:48'),(3,'Aluno 3','aluno3@email.edu.br','aluno3','aluno123','2020-06-19 10:00:48','2020-06-19 10:00:48'),(4,'Aluno 4','aluno4@ftt.edu.br','aluno4','aluno123','2020-06-26 01:09:30','2020-06-26 01:09:30'),(17,'Aluno 5','aluno5@ftt.edu.br','aluno5','aluno123','2020-06-26 12:01:56','2020-06-26 12:01:56');
/*!40000 ALTER TABLE `alunos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log_sistema`
--

DROP TABLE IF EXISTS `log_sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_sistema` (
  `id_Log_Sistema` int NOT NULL AUTO_INCREMENT,
  `id_TipoLogSistema` int NOT NULL,
  `id_Aluno` int DEFAULT NULL,
  `id_Professor` int DEFAULT NULL,
  `Descricao` varchar(150) DEFAULT NULL,
  `Data_Cadastro` datetime NOT NULL,
  `Localizacao` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_Log_Sistema`),
  KEY `fk_logsistema_tipologsistema_idx` (`id_TipoLogSistema`),
  KEY `fk_logsistema_alunos_idx` (`id_Aluno`),
  KEY `fk_logsistema_professores_idx` (`id_Professor`),
  CONSTRAINT `fk_logsistema_alunos` FOREIGN KEY (`id_Aluno`) REFERENCES `alunos` (`id_Aluno`),
  CONSTRAINT `fk_logsistema_professores` FOREIGN KEY (`id_Professor`) REFERENCES `professores` (`id_Professor`),
  CONSTRAINT `fk_logsistema_tipologsistema` FOREIGN KEY (`id_TipoLogSistema`) REFERENCES `tipo_log_sistema` (`id_TipoLogSistema`)
) ENGINE=InnoDB AUTO_INCREMENT=139 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_sistema`
--

LOCK TABLES `log_sistema` WRITE;
/*!40000 ALTER TABLE `log_sistema` DISABLE KEYS */;
INSERT INTO `log_sistema` VALUES (1,1,1,NULL,'Teste de login','2020-05-29 16:18:06',NULL),(2,1,1,NULL,'Teste de login','2020-05-29 16:19:00',NULL),(3,1,1,NULL,'Teste de login','2020-05-29 19:27:52',NULL),(4,1,1,NULL,'Aluno Aluno 1 logou no sistema','2020-05-29 21:00:24',NULL),(5,1,1,NULL,'Aluno 1 logou no sistema','2020-05-29 21:06:20',NULL),(6,2,1,NULL,'Aluno 1 saiu do sistema','2020-05-29 21:07:32',NULL),(7,1,1,NULL,'Aluno 1 logou no sistema','2020-06-02 20:38:51',NULL),(8,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-02 20:39:41',NULL),(9,1,1,NULL,'Aluno 1 logou no sistema','2020-06-02 20:47:03',NULL),(10,1,1,NULL,'Aluno 1 logou no sistema','2020-06-05 19:44:35',NULL),(11,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 13:53:45',NULL),(12,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 13:56:32',NULL),(13,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 13:56:39',NULL),(14,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 13:56:43',NULL),(15,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 13:57:17',NULL),(16,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 14:52:25',NULL),(17,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 14:52:38',NULL),(18,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 14:52:50',NULL),(19,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 14:53:25',NULL),(20,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 14:59:56',NULL),(21,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:00:05',NULL),(22,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:00:18',NULL),(23,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:00:54',NULL),(24,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:04:08',NULL),(25,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:05:10',NULL),(26,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:05:12',NULL),(27,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:05:15',NULL),(28,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:06:47',NULL),(29,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:07:24',NULL),(30,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:16:00',NULL),(31,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:16:33',NULL),(32,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:22:32',NULL),(33,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:23:01',NULL),(34,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:38:15',NULL),(35,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:38:48',NULL),(36,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 15:55:13',NULL),(37,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 15:55:44',NULL),(38,1,1,NULL,'Aluno 1 logou no sistema','2020-06-08 16:11:13',NULL),(39,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-08 16:11:52',NULL),(40,1,1,NULL,'Aluno 1 logou no sistema','2020-06-09 10:18:55',NULL),(41,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-09 10:19:41',NULL),(42,1,1,NULL,'Aluno 1 logou no sistema','2020-06-09 10:22:43',NULL),(43,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-09 10:23:19',NULL),(44,1,1,NULL,'Aluno 1 logou no sistema','2020-06-09 10:37:49',NULL),(45,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-09 10:37:57',NULL),(46,1,1,NULL,'teste','2020-06-24 00:16:13','5444g5d4f5dsfgsd5f'),(47,1,1,NULL,'teste','2020-06-24 00:17:19','5444g5d4f5dsfgsd5f'),(48,1,1,NULL,'Teste de login','2020-06-24 00:19:23','fdsf145s6d4f56sd4fsd64f'),(50,1,1,NULL,'Teste de login','2020-06-24 01:06:11','fdsf145s6d4f56sd4fsd64f'),(51,1,1,NULL,'Teste de login','2020-06-24 01:07:29','fdsf145s6d4f56sd4fsd64f'),(52,1,1,NULL,'Teste de login','2020-06-25 00:18:09','fdsf145s6d4f56sd4fsd64f'),(53,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 00:30:44','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(54,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 00:31:19',NULL),(55,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 00:31:37','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(56,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 00:31:59',NULL),(57,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 00:35:16','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(58,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 00:36:08',NULL),(59,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 01:08:44','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(60,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 01:08:59',NULL),(61,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 01:09:37','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(62,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 01:44:20','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(63,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 01:44:26',NULL),(64,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 15:26:21','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(65,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 15:26:38',NULL),(66,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:00:19','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(67,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:26:22','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(68,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 17:26:52',NULL),(69,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:27:27','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(70,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:30:33','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(71,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:31:26','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(72,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:49:46','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(73,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 17:55:51','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(74,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 18:05:19','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(75,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 18:06:35',NULL),(76,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 18:07:33','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(77,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 18:07:40',NULL),(78,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 18:09:01','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(79,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:34:06','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(80,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:37:02','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(81,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:44:33','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(82,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:45:37',NULL),(83,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:45:39','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(84,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:45:49',NULL),(85,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:45:51','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(86,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:45:54',NULL),(87,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:54:03','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(88,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:54:07',NULL),(89,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:54:09','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(90,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:54:19',NULL),(91,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:59:11','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(92,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:59:14',NULL),(93,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:59:16','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(94,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:59:19',NULL),(95,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 21:59:20','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(96,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 21:59:23',NULL),(97,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 22:01:43','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(98,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 22:01:46',NULL),(99,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 22:45:14','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(100,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 23:55:24','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(101,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-25 23:59:00',NULL),(102,1,1,NULL,'Aluno 1 logou no sistema','2020-06-25 23:59:01','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(103,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 00:01:24',NULL),(104,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:01:35','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(105,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:11:28','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(106,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:13:00','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(107,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:19:56','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(108,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:27:42','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(109,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:28:21','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(110,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 00:29:53',NULL),(111,1,2,NULL,'Aluno 2 logou no sistema','2020-06-26 00:30:01','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(112,1,2,NULL,'Aluno 2 logou no sistema','2020-06-26 00:30:36','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(113,1,2,NULL,'Aluno 2 logou no sistema','2020-06-26 00:32:27','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(114,2,2,NULL,'Aluno 2 saiu do sistema','2020-06-26 00:32:48',NULL),(117,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 00:48:48','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(118,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 00:48:59',NULL),(119,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 01:00:07','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(120,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 01:01:41','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(121,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 01:02:19','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(122,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 01:04:37','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(123,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 01:04:59','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(124,1,3,NULL,'Aluno 3 logou no sistema','2020-06-26 01:05:06','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(125,2,3,NULL,'Aluno 3 saiu do sistema','2020-06-26 01:05:16','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(126,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 01:07:30','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(127,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 01:08:33','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(128,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 01:08:51','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(129,1,4,NULL,'Aluno 4 logou no sistema','2020-06-26 01:09:53','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(130,2,4,NULL,'Aluno 4 saiu do sistema','2020-06-26 01:10:20','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(131,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 11:40:40','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(132,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 11:41:08','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(133,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 12:03:56','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(134,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 12:14:28','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(135,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 13:21:58','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(136,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 13:22:11','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(137,1,1,NULL,'Aluno 1 logou no sistema','2020-06-26 13:22:17','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0'),(138,2,1,NULL,'Aluno 1 saiu do sistema','2020-06-26 13:22:43','Latitude: -23.7359983333333, Longitude: -46.5831316666667, Altitude: 0');
/*!40000 ALTER TABLE `log_sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materiais`
--

DROP TABLE IF EXISTS `materiais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materiais` (
  `id_Material` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Link` varchar(200) NOT NULL,
  PRIMARY KEY (`id_Material`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materiais`
--

LOCK TABLES `materiais` WRITE;
/*!40000 ALTER TABLE `materiais` DISABLE KEYS */;
INSERT INTO `materiais` VALUES (1,'Aula 03 – Pronomes de Tratamento','https://gramaticaemvideo.com.br/aula/aula-03-pronomes-de-tratamento/'),(2,'Aula 04 - Pronomes possessivos','https://www.youtube.com/watch?v=1r-OJYnxgZo'),(3,'Pronomes Relativos','https://www.youtube.com/watch?v=70dyjrhTRKk'),(4,'Pronomes pessoais','https://www.youtube.com/watch?v=PQRdgiIutrE&list=PLVyIxkvuIqxrhBoLoM9Ydk8HOrNXEsQhD'),(5,'Pronomes de tratamento','https://www.youtube.com/watch?v=fYEeSIiIA5E'),(6,'Pronomes Relativos','https://www.youtube.com/watch?v=ocwqxQmGHuU');
/*!40000 ALTER TABLE `materiais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `perguntas`
--

DROP TABLE IF EXISTS `perguntas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perguntas` (
  `id_Pergunta` int NOT NULL AUTO_INCREMENT,
  `id_Questionario` int NOT NULL,
  `Pergunta` varchar(500) NOT NULL,
  PRIMARY KEY (`id_Pergunta`),
  UNIQUE KEY `id_Perguntas_UNIQUE` (`id_Pergunta`),
  KEY `fk_pergunta_questionario_idx` (`id_Questionario`),
  CONSTRAINT `fk_pergunta_questionario` FOREIGN KEY (`id_Questionario`) REFERENCES `questionarios` (`id_Questionario`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perguntas`
--

LOCK TABLES `perguntas` WRITE;
/*!40000 ALTER TABLE `perguntas` DISABLE KEYS */;
INSERT INTO `perguntas` VALUES (1,1,'O pronome de tratamento que melhor completa a oração a seguir é: __________________, cardeal Dom Sérgio da Rocha, acompanhará o Papa em sua visita ao Brasil.'),(2,1,'(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:'),(3,1,'(Prime Concursos) O pronome de tratamento Vossa Reverendíssima é usado para:'),(4,1,'(Crescer Consultoria) Vossa Eminência é o pronome de tratamento utilizado para:'),(5,1,'(Copeve-Ufal) Que frase abaixo apresenta pronome(s) possessivo(s)?'),(6,1,'(IBGP) Assinale a alternativa em que todos os vocábulos são pronomes possessivos.'),(7,1,'(Makiyama) Dentre as frases abaixo, marque aquela em que há uso de pronome possessivo:'),(8,1,'Identifique os pronomes possessivos na frase a seguir e classifique-os em pronome substantivo ou pronome adjetivo: Ele guardou seus documentos. Não guardou os meus.'),(9,1,'(ETF-SP) Em \"O casal de índios levou-os à sua aldeia, que estava deserta, onde ofereceu frutas aos convidados\", temos:'),(10,1,'Assinale o item em que não aparece pronome relativo:'),(11,1,'Assinale o período em que foi empregado um pronome relativo inadequadamente:'),(12,1,'(FUVEST) Conheci que (1) Madalena era boa em demasia... A culpa foi desta vida agreste que (2) me deu uma alma agreste. Procuro recordar o que (3) dizíamos. Terá realmente piado a coruja? Será a mesma que (4) piava há dois anos? Esqueço que (5) eles me deixaram e que (6) esta casa está quase deserta. Nas frases anteriores o \"QUE\" aparece seis vezes; em três delas é pronome relativo. Quais?'),(13,2,'(TTN) Assinale a frase em que a colocação do pronome pessoal oblíquo não obedece às normas do português padrão:'),(14,2,'(IBGE) Assinale a opção em que houve erro no emprego do pronome pessoal em relação ao uso culto da língua:'),(15,2,'(FUVEST) Assinale a alternativa onde o pronome pessoal está empregado corretamente:'),(16,2,'(UF-PR) Aponte a alternativa que contém o período correto quanto à colocação do pronome pessoal:'),(17,2,'(U-UBERLÂNDIA) Assinale o tratamento dado ao reitor de uma Universidade:'),(18,2,'(UF-RJ) Numa das frases, está usado indevidamente um pronome de tratamento. Assinale-a:'),(19,2,'(FMU) Suponha que você deseje dirigir-se a personalidades eminentes, cujos títulos são: papa, juiz, cardeal, reitor e coronel. Assinale a alternativa que contém a abreviatura certa da \"expressão de tratamento\" correspondente ao título enumerado:'),(20,2,'(FCC- modificada) Os pronomes de tratamento estão empregados corretamente em:'),(21,2,'(UEPG-PR) Assinale a alternativa em que a palavra onde funciona como pronome relativo:'),(22,2,'(FIUBE-MG) Assinale o item em que não aparece pronome relativo:'),(23,2,'(FUVEST) Conheci que (1) Madalena era boa em demasia... A culpa foi desta vida agreste que (2) me deu uma alma agreste. Procuro recordar o que (3) dizíamos. Terá realmente piado a coruja? Será a mesma que (4) piava há dois anos? Esqueço que (5) eles me deixaram e que (6) esta casa está quase deserta. Nas frases acima o que aparece seis vezes; em três delas é pronome relativo. Quais?'),(24,2,'(ETF-SP) Em \"O casal de índios levou-os à sua aldeia, que estava deserta, onde ofereceu frutas aos convidados\", temos:'),(25,3,'Durante a execução de um programa, o conteúdo de uma variável pode mudar ao longo do tempo, no entanto ela só pode armazenar um valor por vez.'),(26,3,'Se o algoritmo para o cálculo da média de determinado aluno utilizar a fórmula média = (P1 + 2*P2) / 3, em que P1 e P2 referem-se, respectivamente, às notas do aluno na primeira e na segunda prova, e se a média mínima necessária para o aluno ser aprovado na disciplina for 4,5, esse aluno será aprovado se obtiver nota 5,0 na primeira prova e 4,0 na segunda prova.'),(27,3,'A expressão a seguir especifica que: 1 será adicionado a x, se x for maior que 0; 1 será subtraído de x, se x for menor que 0; o valor de x será mantido, se x for igual a zero. Se (x > 0) então x++; senão if (x < 0) x-- ;'),(28,3,'As estruturas de controle de fluxo WHILE e DO...WHILE possuem a mesma finalidade e seus respectivos blocos de comandos são executados pelo menos uma vez em cada uma delas.'),(29,3,'Utilizando-se linguagens fracamente tipadas, é possível alterar o tipo de dado contido em uma variável durante a execução do programa.'),(30,3,'Em um laço de repetição, o controle do número de vezes que o laço será repetido ocorre por meio de operadores lógicos.'),(31,3,'A estrutura de decisão SE/ENTÃO/SENÃO, ou IF/THEN/ELSE, permite que seja sempre executado um comando. Isso porque, caso a condição seja verdadeira, o comando da condição SE/ENTÃO será executado; caso contrário, o comando da condição SENÃO (falsa) será executado.'),(32,3,'A estrutura a while é um tipo de loop em que o código nela contido será executado até que a condição especificada de parada seja satisfeita.'),(33,3,'O operador lógico de disjunção (ou) é útil em tipos de análise para verificar se todos os valores são verdadeiros, o que, consequentemente, acarretará em todos os resultados serem também verdadeiros.'),(34,3,'Em uma função, os parâmetros podem ser passados por meio de valor; isso, no entanto, implica que a mudança do valor do parâmetro dentro da função irá afetar o valor da variável original.'),(35,4,'Gilda comprou copos descartáveis de 200 mililitros, para servir refrigerantes, em sua festa de aniversário. Quantos copos ela encherá com 1 litro de refrigerante?'),(36,4,'O carro de João consome 1 litro de gasolina a cada 10 quilômetros percorridos. Para ir da sua casa ao sítio, que fica distante 63 quilômetros, o carro irá consumir:'),(37,4,'Uma professora ganhou ingressos para levar 50% de seus alunos ao circo da cidade. A professora leciona para 36 alunos. Quantos alunos ela poderá levar?\r'),(38,4,'A professora do 5º Ano, corrigindo as avaliações da classe, viu que Pedro acertou 20/100 das questões. De que outra forma a professora poderia representar essa fração?'),(39,4,'Se um ano tem 365 dias. Quantos dias tem dois anos , sabendo que um desses anos é bissexto?\r'),(40,4,'Responda a charada. Se um gato tem 4 patas. Quantas patas possuem 56 gatos?'),(41,4,'Quanto é (8 + 8) x 8?'),(42,4,'Quanto é 56 – 21?'),(43,4,'Quanto é [(5 + 3) + 2] * (2 + 3)?'),(44,4,'O temporal ocorrido no mês de março, abriu um enorme buraco na ponte “Edson Serejo” formando uma cratera. Esse fato fez com que a ponte ficasse interditada durante 2 meses. Durante quantas semanas a ponte ficou interditada?');
/*!40000 ALTER TABLE `perguntas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professores`
--

DROP TABLE IF EXISTS `professores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `professores` (
  `id_Professor` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  PRIMARY KEY (`id_Professor`),
  UNIQUE KEY `id_Professor_UNIQUE` (`id_Professor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professores`
--

LOCK TABLES `professores` WRITE;
/*!40000 ALTER TABLE `professores` DISABLE KEYS */;
INSERT INTO `professores` VALUES (1,'Professor 1');
/*!40000 ALTER TABLE `professores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questionarios`
--

DROP TABLE IF EXISTS `questionarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questionarios` (
  `id_Questionario` int NOT NULL AUTO_INCREMENT,
  `id_Professor` int NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Data` datetime NOT NULL,
  PRIMARY KEY (`id_Questionario`),
  UNIQUE KEY `id_Questionario_UNIQUE` (`id_Questionario`),
  KEY `fk_questionario_professor_idx` (`id_Professor`),
  CONSTRAINT `fk_questionario_professor` FOREIGN KEY (`id_Professor`) REFERENCES `professores` (`id_Professor`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questionarios`
--

LOCK TABLES `questionarios` WRITE;
/*!40000 ALTER TABLE `questionarios` DISABLE KEYS */;
INSERT INTO `questionarios` VALUES (1,1,'Português - Gramática','2020-03-14 16:13:42'),(2,1,'Português - Pronomes','2020-05-24 14:16:53'),(3,1,'Algoritmos 1','2020-02-23 11:08:05'),(4,1,'Matemática Básica','2020-03-12 11:07:50');
/*!40000 ALTER TABLE `questionarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respostas`
--

DROP TABLE IF EXISTS `respostas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `respostas` (
  `id_Tentativa` int NOT NULL,
  `id_Alternativa` int NOT NULL,
  PRIMARY KEY (`id_Tentativa`,`id_Alternativa`),
  KEY `fk_resposta_tentativa_idx` (`id_Tentativa`),
  KEY `fk_resposta_alternativa_idx` (`id_Alternativa`),
  CONSTRAINT `fk_resposta_alternativa` FOREIGN KEY (`id_Alternativa`) REFERENCES `alternativas` (`id_Alternativa`),
  CONSTRAINT `fk_resposta_tentativa` FOREIGN KEY (`id_Tentativa`) REFERENCES `tentativas` (`id_Tentativa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respostas`
--

LOCK TABLES `respostas` WRITE;
/*!40000 ALTER TABLE `respostas` DISABLE KEYS */;
INSERT INTO `respostas` VALUES (1,2),(1,5),(1,9),(1,16),(1,17),(1,22),(1,27),(1,29),(1,35),(1,38),(1,41),(1,47),(2,2),(2,8),(2,9),(2,13),(2,19),(2,23),(2,27),(2,29),(2,33),(2,39),(2,41),(2,45),(3,1),(3,6),(3,9),(3,15),(3,17),(3,22),(3,26),(3,30),(3,34),(3,40),(3,43),(3,46),(7,2),(7,5),(7,9),(7,16),(7,17),(7,22),(7,27),(7,29),(7,35),(7,38),(7,41),(7,47),(8,2),(8,5),(8,9),(8,16),(8,17),(8,22),(8,27),(8,29),(8,35),(8,38),(8,41),(8,47),(9,50),(9,54),(9,57),(9,64),(9,67),(9,72),(9,74),(9,80),(9,81),(9,87),(9,90),(9,96),(10,49),(10,53),(10,57),(10,61),(10,65),(10,69),(10,73),(10,77),(10,81),(10,85),(10,89),(10,93),(11,97),(11,100),(11,101),(11,103),(11,106),(11,108),(11,109),(11,111),(11,114),(11,115),(12,118),(12,123),(12,126),(12,131),(12,134),(12,137),(12,141),(12,147),(12,149),(12,155),(13,1),(13,6),(13,9),(13,16),(13,19),(13,23),(13,28),(13,29),(13,34),(13,38),(13,42),(13,48),(14,49),(14,54),(14,59),(14,64),(14,65),(14,70),(14,74),(14,79),(14,84),(14,86),(14,92),(14,96),(15,97),(15,100),(15,102),(15,103),(15,106),(15,108),(15,109),(15,112),(15,113),(15,116),(16,118),(16,123),(16,126),(16,131),(16,133),(16,137),(16,141),(16,147),(16,149),(16,155);
/*!40000 ALTER TABLE `respostas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tentativas`
--

DROP TABLE IF EXISTS `tentativas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tentativas` (
  `id_Tentativa` int NOT NULL AUTO_INCREMENT,
  `id_Aluno` int NOT NULL,
  `id_Questionario` int NOT NULL,
  `id_Material` int DEFAULT NULL,
  `id_Material_Knn` int DEFAULT NULL,
  PRIMARY KEY (`id_Tentativa`),
  KEY `fk_tentativa_resposta_idx` (`id_Aluno`),
  KEY `fk_tentativa_questionario` (`id_Questionario`),
  KEY `fk_tentativa_material` (`id_Material`),
  KEY `fk_tentativa_material_knn` (`id_Material_Knn`),
  CONSTRAINT `fk_tentativa_aluno` FOREIGN KEY (`id_Aluno`) REFERENCES `alunos` (`id_Aluno`),
  CONSTRAINT `fk_tentativa_material` FOREIGN KEY (`id_Material`) REFERENCES `materiais` (`id_Material`),
  CONSTRAINT `fk_tentativa_material_knn` FOREIGN KEY (`id_Material_Knn`) REFERENCES `materiais` (`id_Material`),
  CONSTRAINT `fk_tentativa_questionario` FOREIGN KEY (`id_Questionario`) REFERENCES `questionarios` (`id_Questionario`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tentativas`
--

LOCK TABLES `tentativas` WRITE;
/*!40000 ALTER TABLE `tentativas` DISABLE KEYS */;
INSERT INTO `tentativas` VALUES (1,1,1,3,NULL),(2,2,1,1,NULL),(3,3,1,1,NULL),(7,1,1,NULL,NULL),(8,1,1,NULL,NULL),(9,1,2,NULL,NULL),(10,1,2,NULL,NULL),(11,1,3,NULL,NULL),(12,1,4,NULL,NULL),(13,1,1,NULL,NULL),(14,2,2,NULL,NULL),(15,2,3,NULL,NULL),(16,1,4,NULL,NULL);
/*!40000 ALTER TABLE `tentativas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_log_sistema`
--

DROP TABLE IF EXISTS `tipo_log_sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_log_sistema` (
  `id_TipoLogSistema` int NOT NULL AUTO_INCREMENT,
  `Descricao` varchar(100) NOT NULL,
  PRIMARY KEY (`id_TipoLogSistema`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_log_sistema`
--

LOCK TABLES `tipo_log_sistema` WRITE;
/*!40000 ALTER TABLE `tipo_log_sistema` DISABLE KEYS */;
INSERT INTO `tipo_log_sistema` VALUES (1,'Login'),(2,'Logout');
/*!40000 ALTER TABLE `tipo_log_sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_material_indicado`
--

DROP TABLE IF EXISTS `view_material_indicado`;
/*!50001 DROP VIEW IF EXISTS `view_material_indicado`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_material_indicado` AS SELECT 
 1 AS `id_Questionario`,
 1 AS `Combinacao`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `view_material_indicado`
--

/*!50001 DROP VIEW IF EXISTS `view_material_indicado`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_material_indicado` AS with `cte` as (select `t`.`id_Tentativa` AS `id_tentativa`,`t`.`id_Aluno` AS `id_aluno`,`a`.`Nome` AS `nome`,`t`.`id_Material` AS `id_material`,`m`.`Nome` AS `material`,`t`.`id_Questionario` AS `id_questionario`,`al`.`id_Pergunta` AS `id_pergunta`,`r`.`id_Alternativa` AS `id_alternativa`,`al`.`Alternativa_Correta` AS `alternativa_correta` from ((((`tentativas` `t` join `alunos` `a`) join `materiais` `m`) join `respostas` `r`) join `alternativas` `al`) where ((`t`.`id_Aluno` = `a`.`id_Aluno`) and (`t`.`id_Material` = `m`.`id_Material`) and (`r`.`id_Tentativa` = `t`.`id_Tentativa`) and (`al`.`id_Alternativa` = `r`.`id_Alternativa`)) order by `a`.`id_Aluno`,`al`.`id_Pergunta`) select `cte`.`id_questionario` AS `id_Questionario`,concat(convert(group_concat(`cte`.`alternativa_correta` separator ',') using utf8mb4),',',`cte`.`id_material`) AS `Combinacao` from `cte` group by `cte`.`id_aluno` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-26 13:46:38

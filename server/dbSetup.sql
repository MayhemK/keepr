CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture',
  cover_img VARCHAR(255) COMMENT 'User Cover Image'
) default charset utf8mb4 COMMENT '';

ALTER TABLE  vaults
ADD COLUMN
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP


CREATE TABLE vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TINYTEXT NOT NULL,
  description TEXT NOT NULL,
  img TEXT NOT NULL,
  is_private BOOLEAN NOT NULL DEFAULT false,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
)


CREATE TABLE keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TINYTEXT NOT NULL, 
  description TEXT NOT NULL,
  img TEXT NOT NULL,
  views TINYINT UNSIGNED NOT NULL DEFAULT 0,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
)

DROP TABLE keeps

CREATE TABLE vaultkeep(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  creator_id VARCHAR(255) NOT NULL,
  vault_id INT NOT NULL,
  keep_id INT NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vault_id) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keep_id) REFERENCES keeps(id) ON DELETE CASCADE
)

DROP TABLE `vaultKeep`

SELECT
    vaultKeep.*,
    keeps.*,
    accounts.*
    FROM vaultKeep
    INNER JOIN accounts ON accounts.id = vaultKeep.creator_id
    INNER JOIN keeps ON keeps.id = vaultKeep.keep_id
    WHERE vaultKeep.vault_id = 106;

    SELECT
    keeps.*,
    accounts.*
    FROM keeps 
    JOIN accounts ON keeps.creatorId = account.id
    WHERE creator_id = 67e32349d1583cd79fcfd0a4 ;

        SELECT
    vaults.*,
    accounts.*
    FROM vaults
    JOIN accounts ON vaults.creator_Id = accounts.id
    WHERE vaults.creator_Id = 67e32349d1583cd79fcfd0a4;
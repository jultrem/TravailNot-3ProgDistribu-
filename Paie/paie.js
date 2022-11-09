const express = require('express')
const mariadb = require('mariadb');
const app = express()
const port = 3000
const pool = mariadb.createPool({
    host: 'mariadb', 
    user:'root', 
    password: 'toor',
    database: 'fleuron'
});

app.get('/paye/talons', async (req, res) => {
  if (req.query.employe)
    row = await listerTalonsParEmploye(req.query.employe)
  else
  {
    row = await listerTalons()
  }
  res.send(row)
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})


async function listerTalons() {
  let conn;
  try {
	  conn = await pool.getConnection();
    list = {}
	  const rows = await conn.query("SELECT TalonID, EmployeID, Contenu FROM talons");
    conn.end()
	  return rows 
  } catch (err) {
    console.log(err)
	throw err
  }
}

async function listerTalonsParEmploye(employeId) {
    let conn; 
    try {
      conn = await pool.getConnection();
      list = {};
      const rows = await conn.query("SELECT TalonID, EmployeID, Contenu FROM talons WHERE EmployeID=?",[employeId])
      conn.end()
      return rows
    } catch (err) {
      console.log(err)
      throw err
    }
  }
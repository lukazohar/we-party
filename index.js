const express = require('express');
const app = express();

app.use(express.static('./www/'));

app.use(function (req, res, next) {
  res.header('Access-Control-Allow-Origin', '*');
  res.header('Access-Control-Allow-Credentials', true);
  res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE,OPTIONS');
  res.header(
    'Access-Control-Allow-Headers',
    'Origin,X-Requested-With,Content-Type,Accept,content-type,application/json',
  );
  next();
});

const port = process.env.PORT || 3333;
app.listen(port, () =>
  console.log(`we-party listening at http://localhost:${port}`),
);

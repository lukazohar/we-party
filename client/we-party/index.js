const express = require('express');
const app = express();

app.use(express.static('./www/'));

const port = process.env.PORT || 3333;
app.listen(port, () =>
  console.log(`we-party listening at http://localhost:${port}`),
);

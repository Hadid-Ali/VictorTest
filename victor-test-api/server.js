// A minimal Express server that just returns the stored JSON color
import express from "express";
import fs from "fs";

const app = express();
const PORT = 8000;
const FILE = "./color.json";

// Return the stored JSON color
app.get("/color", (req, res) => {
  try {
    const data = fs.readFileSync(FILE, "utf8");
    res.setHeader("Content-Type", "application/json");
    res.send(data);
  } catch (err) {
    res.status(500).json({ error: "Could not read color file." });
  }
});

app.listen(PORT, () => {
  console.log(`Color API running at http://localhost:${PORT}`);
});

import express from "express";
import fs from "fs";

const app = express();
const PORT = 8000;
const FILE = "./color.json";

app.use(express.json()); // allow JSON in POST body

// GET color (already works)
app.get("/color", (req, res) => {
  try {
    const data = fs.readFileSync(FILE, "utf8");
    res.setHeader("Content-Type", "application/json");
    res.send(data);
  } catch (err) {
    res.status(500).json({ error: "Could not read color file." });
  }
});

// POST color (new route)
app.post("/color", (req, res) => {
  const { r, g, b, a } = req.body;

  // Simple validation
  if (
    typeof r !== "number" ||
    typeof g !== "number" ||
    typeof b !== "number" ||
    typeof a !== "number"
  ) {
    return res.status(400).json({ error: "Invalid color data." });
  }

  const color = { r, g, b, a };

  try {
    fs.writeFileSync(FILE, JSON.stringify(color, null, 2)); // pretty-print
    res.status(200).json({ message: "Color updated successfully.", color });
  } catch (err) {
    res.status(500).json({ error: "Failed to write color file." });
  }
});

app.listen(PORT, () => console.log(`Color API running at http://localhost:${PORT}`));

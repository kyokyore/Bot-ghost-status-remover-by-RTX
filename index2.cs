const discord = require("discord.js");
const { GoogleGenerativeAI } = require("@google/generative-ai");
require('dotenv').config();
const MODEL = "gemini-pro";
const API_KEY = process.env.API_KEY || "";
const BOT_TOKEN = process.env.BOT_TOKEN || "";
const CHANNEL_ID = process.env.CHANNEL_ID || "";

const ai = new GoogleGenerativeAI(API_KEY);
const model = ai.getGenerativeModel({ model: MODEL });

const client = new discord.Client({
  intents: Object.keys(discord.GatewayIntentBits),
});

client.on("ready", () => {
  console.log("Bot is ready!");
});

client.login(BOT_TOKEN);

client.on("messageCreate", async (message) => {
  try {
    if (message.author.bot) return;
    if (message.channel.id !== CHANNEL_ID) return;

    const { response } = await model.generateContent(message.cleanContent);

    message.reply({
      content: response.text(),
    });
  } catch (error) {
    console.error("Error:", error.message);
    console.error(error.stack);
  }
});

const express = require('express');
const app = express();
const port = 3000;

app.get('/', (req, res) => res.send('Hello World!'));

app.listen(port, () => console.log(`Example app listening at http://localhost:${port}`));

// ================= START BOT CODE ===================
const Discord = require('discord.js');

client.on('ready', () => {
  console.log(`Logged in as ${client.user.tag}!`);
});

client.on('message', msg => {
  if (msg.content === 'ping') {
    msg.reply('pong!');
  }
});
// You really don't want your token here since your repl's code
// is publically available. We'll take advantage of a Repl.it 
// feature to hide the token we got earlier. 
client.login(process.env.DISCORD_TOKEN);

#!/usr/bin/python3

#	chatbot.py
#	Developed by Julia Hohenadel
#       Adapted by Sophie Mlodzik

import json
import requests
import telegram
import logging

from telegram.error import NetworkError
from time import sleep
from telegram.ext import Updater, CommandHandler, MessageHandler, Filters

#Get the Token:
TOKEN = "992857589:AAGvnyvJtEebpasSGLQwTAj6b-4LD_aTEoI"

URL = "https://api.telegram.org/bot{}/".format(TOKEN)

bot = telegram.Bot(token = TOKEN)
bot = telegram.Bot(TOKEN, True, 4)
updater = Updater(TOKEN, use_context=True)
dispatcher = updater.dispatcher

logging.basicConfig(format='%(asctime)s - %(name)s - %(levelname)s - %(message)s',
                     level=logging.INFO)

#Some text:
support = "Need immediate support? Check  out the resources below-"
support1 = "Suicide Hotline: 1-800-273-8255"
support2 = "Kids Help Phone: 1-800-668-6868"
support3 = "HERE 247: 1 844 437 3247 (1-800-HERE-247)"
support4 = "Or if you need emergency support, call 911"

family = "Family problems and disagreements can cause a lot of tension for everyone."
family1 = "Try some of the following:\n -speaking calmly and express your ideas politely \n -try to understand the other persons point of view \n -be honest about how you're feeling \n -actively listen"
family2 = "If this doesn't work, recommend taking a break and returning to the discussion again later."
family3 = "Remember that progress in family relationships takes time, so don't become discouraged :)"

friends = "Problems with friends are often very stressful, especially when those friends are a part of your daily life."
friends1 = "Try some of the following:\n -redirecting the conversation to a common interest \n -taking a break by playing a video game \n -calmly talking it out with a trusted adult"
friends2 = "If the discussion gets too intense, remember to take a break- both of you will appreciate it."

#MAIN###############################################################


#START##########################################################
def start(update, context):
    context.bot.sendMessage(chat_id=update.message.chat_id, text="Hi! I'm the mental health bot! I'm here to support you however you need :) \n Type \'/\' for some quick info!")

start_handler = CommandHandler('start', start);
dispatcher.add_handler(start_handler)
#INSTANT SUPPORT########################################################
def instant_support(update, context):
    context.bot.sendMessage(chat_id=update.message.chat_id, text= support)
    context.bot.sendMessage(chat_id=update.message.chat_id, text= support1) 
    context.bot.sendMessage(chat_id=update.message.chat_id, text= support2) 
    context.bot.sendMessage(chat_id=update.message.chat_id, text= support3) 
    context.bot.sendMessage(chat_id=update.message.chat_id, text= support4) 
 
support_handler = CommandHandler('instant_support', instant_support);
dispatcher.add_handler(support_handler)
#FAMILY PROBLEMS##################################################
def family_problems(update, context):
    context.bot.sendMessage(chat_id=update.message.chat_id, text=family)
    context.bot.sendMessage(chat_id=update.message.chat_id, text=family1)
    context.bot.sendMessage(chat_id=update.message.chat_id, text=family2)
    context.bot.sendMessage(chat_id=update.message.chat_id, text=family3)

family_handler = CommandHandler('family_problems', family_problems);
dispatcher.add_handler(family_handler)
#FRIENDSHIP PROBLEMS##################################################
def friendship_problems(update, context):
    context.bot.sendMessage(chat_id=update.message.chat_id, text=friends)
    context.bot.sendMessage(chat_id=update.message.chat_id, text=friends1)
    context.bot.sendMessage(chat_id=update.message.chat_id, text=friends2)

friends_handler = CommandHandler('friendship_problems', friendship_problems);
dispatcher.add_handler(friends_handler)
##################################################################   
#def echo(bot, update):
#	"""Echo the user message."""
#	text = update.message.text.lower()
#	if text[9:13] == "tfsa":
#		bot.sendMessage(chat_id = update.message.chat_id, text = tfsa)
#		bot.sendMessage(chat_id = update.message.chat_id, text = tfsaPros)
#		bot.sendMessage(chat_id = update.message.chat_id, text = tfsaCons)
#	elif text[9:13] == "resp" or text[10:14] == "resp":
#		bot.sendMessage(chat_id = update.message.chat_id, text = resp)
#		bot.sendMessage(chat_id = update.message.chat_id, text = respPros)
#		bot.sendMessage(chat_id = update.message.chat_id, text = respCons)
#	elif text[9:26] == "compound interest":
#		bot.sendMessage(chat_id = update.message.chat_id, text = cmpInt)
#	elif text[9:22] == "credit score":
#		bot.sendMessage(chat_id = update.message.chat_id, text = credit)
#		bot.sendMessage(chat_id = update.message.chat_id, text = creditSc)
#		bot.sendMessage(chat_id = update.message.chat_id, text = creditPitch)
#	else:
#		bot.sendMessage(chat_id=update.message.chat_id, text="Sorry, I don't understand your question :( Remember to type: \"What's a\"...")
#		
#dispatcher.add_handler(MessageHandler(Filters.text, echo))

updater.start_polling()
updater.idle()

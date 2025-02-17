using Newtonsoft.Json;

namespace Tonnage
{
    internal class Update
    {
        [JsonProperty("update_id")]
        public int UpdateId { get; set; }

        [JsonProperty("message")]
        public Message? Message { get; set; }

        [JsonProperty("edited_message")]
        public Message? EditedMessage { get; set; }

        [JsonProperty("channel_post")]
        public Message? ChannelPost { get; set; }

        [JsonProperty("edited_channel_post")]
        public Message? EditedChannelPost { get; set; }

        [JsonProperty("inline_query")]
        public InlineQuery? InlineQuery { get; set; }

        [JsonProperty("chosen_inline_result")]
        public ChosenInlineResult? ChosenInlineResult { get; set; }

        [JsonProperty("callback_query")]
        public CallbackQuery? CallbackQuery { get; set; }

        [JsonProperty("shipping_query")]
        public ShippingQuery? ShippingQuery { get; set; }

        [JsonProperty("pre_checkout_query")]
        public PreCheckoutQuery? PreCheckoutQuery { get; set; }

        [JsonProperty("poll")]
        public Poll? Poll { get; set; }

        [JsonProperty("poll_answer")]
        public PollAnswer? PollAnswer { get; set; }

        [JsonProperty("my_chat_member")]
        public ChatMemberUpdated? MyChatMember { get; set; }

        [JsonProperty("chat_member")]
        public ChatMemberUpdated? ChatMember { get; set; }

        [JsonProperty("chat_join_request")]
        public ChatJoinRequest? ChatJoinRequest { get; set; }
    }
}
